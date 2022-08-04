using Allup.DAL;
using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.ViewComponents
{
    public class ModalViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public ModalViewComponent(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            //test
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userName = "";
            ViewBag.User = "";
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.User = (await _userManager.FindByNameAsync(User.Identity.Name)).UserName;
                userName = User.Identity.Name;

            }
            ViewBag.totalCount = 0;
            ViewBag.totalPrice = 0;
            List<BasketVM> prodList =new List<BasketVM>();
            string basket = Request.Cookies[$"{userName}basket"];
            if (basket != null)
            {
                 prodList = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                foreach (var item in prodList)
                {
                    Product dbProd = _context.Products.FirstOrDefault(p => p.Id == item.Id);
                    ProductImage dbImage = _context.ProductImages.Where(p => p.IsMain == true).FirstOrDefault(p => p.ProductId == dbProd.Id);

                    item.Price = dbProd.Price;
                    item.ImgUrl = dbImage.ImgUrl;
                    item.Name = dbProd.Name;
                    item.CategoryId = dbProd.CategoryId;
                    item.BrandId = dbProd.BrandId;
                }
                int totalCount = 0;
                double totalPrice = 0;
                foreach (var item in prodList)
                {
                    totalCount += item.ProductCount;
                    totalPrice += (item.Price * item.ProductCount);
                }
                ViewBag.totalCount = totalCount;
                ViewBag.totalPrice = totalPrice;
            }
            else
            {
                ViewBag.totalCount = 0;
                ViewBag.totalPrice = 0;
            }
            //HeaderVM headerVM = new HeaderVM();
            //headerVM.Bio = await _context.Bios.FirstOrDefaultAsync();
            //headerVM.Categories = await _context.Categories.Include(p => p.Children).ToListAsync();
            //headerVM.Languages = await _context.Languages.ToListAsync();

            return View(await Task.FromResult(prodList));

        }
    }
}
