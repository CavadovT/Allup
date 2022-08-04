using Allup.DAL;
using Allup.Extentions;
using Allup.Helpers;
using Allup.Interfaces;
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
        private readonly IEmailService _eservice;
        public ProductController(AppDbContext context, IWebHostEnvironment environment, IEmailService emailService)
        {
            _context = context;
            _env = environment;
            _eservice = emailService;
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
                .Include(p => p.OrderProducts)
                .ThenInclude(p => p.Order)
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
                var errors = ModelState.Values.SelectMany(errors => errors.Errors);
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);

                }
                return View();

            }
           
            bool IsExistName = await _context.Products.Where(p => p.IsDelete == false).AnyAsync(p => p.Name.ToLower().Contains(product.Name.ToLower()));
            if (IsExistName)
            {
                ModelState.AddModelError("Name", "this product alredy exist");
                return View();
            }
            if (product.Photos == null)
            {
                ModelState.AddModelError("Photos", "Please choose the photo");
                return View();
            }
            List<ProductImage> images = new List<ProductImage>();

            foreach (var img in product.Photos)
            {
                if (img == null)
                {
                    ModelState.AddModelError("Photos", "Don't leave it blank!!!");
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


            List<string> emails = await _context.Subscribers.Select(x => x.Email).ToListAsync();
            
            _eservice.SendEmail(emails, "New Product", $"Name of product: {newProduct.Name},Price:{newProduct.Price} https://preview.themeforest.net/item/allup-electronics-ecommerce-html5-template/full_screen_preview/27042714?_ga=2.94426207.2135673103.1659419617-1585959507.1656861724");

            
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

            foreach (var img in await _context.ProductImages.Where(i => i.ProductId == id).Where(i => i.IsMain == false).ToListAsync())
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
                .Include(p => p.TagProducts)
                .ThenInclude(tp => tp.Tag)
                .FirstOrDefaultAsync(c => c.Id == id);
            ViewBag.Img = (await _context.ProductImages.Where(i => i.ProductId == id).Where(i => i.IsMain == true).FirstOrDefaultAsync()).ImgUrl;

            if (dbProd == null) return NotFound();

            return View(dbProd);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Product dbProd = await _context.Products
                .Where(p => p.IsDelete == false)
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.ProductImages)
                .Include(p => p.TagProducts)
                .ThenInclude(tp => tp.Tag)
                .FirstOrDefaultAsync(c => c.Id == id);

            ViewBag.Categories = new SelectList(await _context.Categories.Where(c => c.IsDeleted == false).Where(c => c.ParentId != null).ToListAsync(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync(), "Id", "Name");
            ViewBag.Tags = new SelectList(await _context.Tags.ToListAsync(), "Id", "Name");
            List<Tag> tags = await _context.Tags.ToListAsync();
            List<string> tagNames = new List<string>();

            foreach (var item in dbProd.TagProducts)
            {
                tagNames.Add(item.Tag.Name);
            }
            dbProd.TagNames = tagNames;
            dbProd.Tags = tags;
            return View(dbProd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product, List<int> TgIdss)
        {
            Product dbProduct = _context.Products
              .Include(p => p.ProductImages)
              .Include(p => p.Category)
              .Include(p => p.Brand)
              .Include(p => p.TagProducts)
              .ThenInclude(p => p.Tag)
              .FirstOrDefault(c => c.Id == product.Id);
            ViewBag.Categories = new SelectList(await _context.Categories.Where(c => c.IsDeleted == false).Where(c => c.ParentId != null).ToListAsync(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync(), "Id", "Name");

            List<Tag> tags = await _context.Tags.ToListAsync();
            List<string> tagNames = new List<string>();

            foreach (var item in dbProduct.TagProducts)
            {
                tagNames.Add(item.Tag.Name);
            }
            dbProduct.TagNames = tagNames;
            dbProduct.Tags = tags;

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(errors => errors.Errors);
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);

                }
                return View(dbProduct);
            }

            if (dbProduct == null)
            {
                return View(dbProduct);
            }
            else
            {
                if (product.DiscountPercent != null)
                {
                    dbProduct.DiscountPrice = product.Price - (product.Price * product.DiscountPercent / 100);
                }
                else
                {
                    dbProduct.DiscountPrice = product.Price;
                }

                if (product.Photos == null)
                {
                    dbProduct.ProductImages = dbProduct.ProductImages;
                }
                else
                {
                    foreach (var item in dbProduct.ProductImages)
                    {
                        string oldPhoto = item.ImgUrl;
                        string path = Path.Combine(_env.WebRootPath, "assets/images/product", oldPhoto);

                        Helper.DeleteImage(path);
                    }

                    List<ProductImage> images = new List<ProductImage>();

                    foreach (var img in product.Photos)
                    {
                        if (img == null)
                        {
                            ModelState.AddModelError("Photos", "don't leave it blank!!!");
                            return View(dbProduct);
                        }
                        if (!img.IsImage())
                        {
                            ModelState.AddModelError("Photos", "Choose the photo");
                            return View(dbProduct);
                        }
                        if (img.ValidSize(200))
                        {
                            ModelState.AddModelError("Photos", "oversize");
                            return View(dbProduct);
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
                    dbProduct.ProductImages = images;
                }
                List<TagProducts> newtagProducts = new List<TagProducts>();
                foreach (var tagId in TgIdss)
                {
                    TagProducts newtagProduct = new TagProducts();
                    newtagProduct.ProductId = product.Id;
                    newtagProduct.TagId = tagId;
                    newtagProducts.Add(newtagProduct);
                }
                Product dbProductName = _context.Products.FirstOrDefault(c => c.Name.Trim().ToLower() == product.Name.Trim().ToLower());

                if (dbProductName != null)
                {
                    if (dbProductName.Name.Trim().ToLower() != dbProduct.Name.Trim().ToLower())
                    {
                        ModelState.AddModelError("Name", "This category is already exist");
                        return View(dbProduct);
                    }
                }

                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                dbProduct.Description = product.Description;
                dbProduct.Count = product.Count;
                dbProduct.TaxPercent = product.TaxPercent;
                dbProduct.DiscountPercent = product.DiscountPercent;
                dbProduct.CategoryId = product.CategoryId;
                dbProduct.BrandId = product.BrandId;
                dbProduct.IsBestSeller = product.IsBestSeller;
                dbProduct.IsFeatured = product.IsFeatured;
                dbProduct.IsNewArrivel = product.IsNewArrivel;
                dbProduct.TagProducts = newtagProducts;
                dbProduct.UpdatedAt = DateTime.Now;
                _context.SaveChanges();

            }
            return RedirectToAction("index");
        }

    }
}
