using Allup.DAL;
using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.Controllers
{
    public class BasketController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public BasketController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        /// <summary>
        /// Basket controller Index Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Add product to basket Action
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddItem(int? Id)
        {
            string userName = "";
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            if (Id == null) return NotFound();

            Product dbProd = await _context.Products
                .Where(p=>p.IsDelete==false)
                .Include(p=>p.ProductImages)
                .Include(p=>p.Category)
                .Include(p=>p.Brand)
                .FirstOrDefaultAsync(p=>p.Id==Id);

            if (dbProd == null) return NotFound();
            List<BasketVM> products;

            string basket = Request.Cookies[$"{userName}basket"];

            if (basket == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }

            BasketVM IsExist = products.Find(p => p.Id == Id);

            if (IsExist == null)
            {
                BasketVM prodVM = new BasketVM
                {
                    Id = dbProd.Id,
                    ProductCount = 1,
                    Price = dbProd.Price,
                    Name = dbProd.Name,
                    CategoryId = dbProd.CategoryId,
                    BrandId = dbProd.BrandId,
                    ImgUrl = (await _context.ProductImages.Where(i => i.IsMain == true).FirstOrDefaultAsync(i => i.ProductId == dbProd.Id)).ImgUrl,

                };
                products.Add(prodVM);
            }
            else
            {
                IsExist.ProductCount++;

            }

            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(3) });
            return RedirectToAction("index", "shop");
        }
        /// <summary>
        /// Show card action
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ShowItem()
        {

            string userName = "";
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            List<BasketVM> prods;
            string basket = Request.Cookies[$"{userName}basket"];
            if (basket != null)
            {
                prods = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in prods)
                {
                    Product dbProd = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.Id);
                    ProductImage dbPrIm = await _context.ProductImages.Where(pi => pi.IsMain == true).FirstOrDefaultAsync(pi => pi.ProductId == dbProd.Id);
                    item.Price = dbProd.Price;
                    item.ImgUrl = dbPrIm.ImgUrl;
                    item.Name = dbProd.Name;
                    item.CategoryId = dbProd.CategoryId;
                    item.BrandId = dbProd.BrandId;
                }
            }
            else
            {
                prods = new List<BasketVM>();
            }
            return View(prods);
        }
        /// <summary>
        /// product minus at basket Action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult minusBtn(int id)
        {
            string userName = "";
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }

            string basket = Request.Cookies[$"{userName}basket"];

            List<BasketVM> prods = JsonConvert.DeserializeObject<List<BasketVM>>(basket);


            BasketVM product = prods.Find(p => p.Id == id);
            if (product.ProductCount > 1)
            {
                product.ProductCount--;
            }
            else
            {
                prods.Remove(product);
            }

            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(prods), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });

            return RedirectToAction("ShowItem", "basket");
        }
        /// <summary>
        /// Product plus action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult plusBtn(int id)
        {
            string userName = "";
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            string basket = Request.Cookies[$"{userName}basket"];

            List<BasketVM> prods = JsonConvert.DeserializeObject<List<BasketVM>>(basket);


            BasketVM product = prods.Find(p => p.Id == id);

            product.ProductCount++;


            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(prods), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });

            return RedirectToAction("ShowItem", "basket");
        }
        /// <summary>
        /// remove product at basket-- action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RemoveItem(int id)
        {
            string userName = "";
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            string basket = Request.Cookies[$"{userName}basket"];

            List<BasketVM> prods = JsonConvert.DeserializeObject<List<BasketVM>>(basket);


            BasketVM product = prods.Find(p => p.Id == id);

            prods.Remove(product);


            Response.Cookies.Append($"{userName}basket", JsonConvert.SerializeObject(prods), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });

            return RedirectToAction("ShowItem", "basket");
        }

    }
}
