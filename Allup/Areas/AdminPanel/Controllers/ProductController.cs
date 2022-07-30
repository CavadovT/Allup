using Allup.DAL;
using Allup.Extentions;
using Allup.Helpers;
using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _env = environment;
        }
        /// <summary>
        /// Index action for Product
        /// </summary>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns></returns>

        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            ViewBag.Page = page;

            List<Product> products = await _context.Products.Where(p => p.IsDelete == false)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.ProductImages)
                .Include(p => p.TagProducts)
                .ThenInclude(tp => tp.Tag)
                .Include(p => p.OrderItems)
                .Include(p => p.BasketItems)
                .Skip((page - 1) * take).Take(take).ToListAsync();

            int pageCount = await PageCount(take);
            PaginationVM<Product> pagVM = new PaginationVM<Product>(products, await PageCount(take), page);
            return View(pagVM);

        }
        private async Task<int> PageCount(int take)
        {
            List<Product> products = await _context.Products.Where(p => p.IsDelete == false)
              .ToListAsync();

            if (products.Count % take == 0)
            {
                return (int)Math.Ceiling((decimal)(products.Count() / take));
            }
            else
            {
                return (int)Math.Ceiling((decimal)(products.Count() / take)) + 1;
            }
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = new SelectList(await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _context.Categories.Where(c => c.IsDeleted == false).Where(c => c.ParentId != null).ToListAsync(), "Id", "Name");
            ViewBag.Tags = new SelectList(await _context.Tags.ToListAsync(), "Id", "Name");

            return View();
        }
        /// <summary>
        /// Creaet product action post
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, bool isfeature, bool isnew, bool isbest)
        {
            ViewBag.Brands = new SelectList(await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _context.Categories.Where(c => c.IsDeleted == false).Where(c => c.ParentId != null).ToListAsync(), "Id", "Name");
            ViewBag.Tags = new SelectList(await _context.Tags.ToListAsync(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(errors=>errors.Errors);
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);

                }
                return View();
                
            }
            if (product.Photos==null)
            {
                ModelState.AddModelError("Photos", "Please chose the photo");
                return View();
            }
            List<ProductImage> images = new List<ProductImage>();

            foreach (var img in product.Photos)
            {
                if (img == null)
                {
                    ModelState.AddModelError("Photos", "don't leave it blank!!!");
                    return View();
                }
                if (!img.IsImage())
                {
                    ModelState.AddModelError("Photos", "Choose the photo");
                    return View();
                }
                if (img.ValidSize(200))
                {
                    ModelState.AddModelError("Photos", "oversize");
                    return View();
                }
                ProductImage image = new ProductImage();
                image.ImgUrl = img.SaveImage(_env, "assets/images/product");
                if (product.Photos.Count == 1)
                {
                    image.IsMain = true;
                }
                else 
                {
                    for (int i = 0; i < images.Count; i++)
                    {
                        images[0].IsMain = true;
                    }
                }

                images.Add(image);
            }
            Product newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ProductImages = images,
                Count = product.Count,
                TaxPercent = product.TaxPercent,
                DiscountPercent = product.DiscountPercent,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                IsBestSeller = isbest,
                IsFeatured = isfeature,
                IsNewArrivel = isnew,
                CreatedAt = DateTime.Now,

            };
            if (product.DiscountPercent != null)
            {
                newProduct.DiscountPrice = product.Price - (product.Price * product.DiscountPercent / 100);
            }
            else 
            {
                newProduct.DiscountPrice = product.Price;
            }

            List<TagProducts> tagProducts = new List<TagProducts>();
            foreach (var tagId in product.TagIds)
            {
                TagProducts tagProduct = new TagProducts();
                tagProduct.ProductId = product.Id;
                tagProduct.TagId = tagId;
                tagProducts.Add(tagProduct);
            }
            newProduct.TagProducts = tagProducts;

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        /// <summary>
        /// delete action for product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Product dbProd = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
            if (dbProd == null) return NotFound();

            foreach (var img in await _context.ProductImages.Where(i => i.ProductId == id).Where(i=>i.IsMain==false).ToListAsync())
            {
                string path = Path.Combine(_env.WebRootPath, "assets/images/product", img.ImgUrl);

                Helper.DeleteImage(path);
            }
            dbProd.DeletedAt = DateTime.Now;
            dbProd.IsDelete = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        /// <summary>
        /// detail action for product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int? id) 
        {
            if (id == null) return NotFound();
            Product dbProd = await _context.Products
                .Where(p => p.IsDelete == false)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p=>p.TagProducts)
                .ThenInclude(tp=>tp.Tag)
                .FirstOrDefaultAsync(c => c.Id == id);
            ViewBag.Img=(await _context.ProductImages.Where(i=>i.ProductId==id).Where(i=>i.IsMain==true).FirstOrDefaultAsync()).ImgUrl;
           
            if (dbProd == null) return NotFound();
            
            return View(dbProd);
          
        }
    }
}
