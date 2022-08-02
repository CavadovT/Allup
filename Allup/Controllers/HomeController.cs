using Allup.DAL;
using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = await _context.Sliders.ToListAsync();
            homeVM.Categories = await _context.Categories.Where(c=>c.IsDeleted==false).ToListAsync();
            homeVM.Banners = await _context.Banners.ToListAsync();
            homeVM.Brands= await _context.Brands.ToListAsync();
            homeVM.Products=await _context.Products.Where(p=>p.IsDelete==false).Include(p=>p.Category).Include(p=>p.ProductImages).ToListAsync();
            homeVM.Blogs=await _context.Blogs.OrderByDescending(b=>b.Id).Skip(3).ToListAsync();
            homeVM.Testonominal = await _context.Testonominals.FirstOrDefaultAsync();
           
            return View(homeVM);
        }
        public IActionResult Search(string search)
        {
            List<Product> products = _context.Products.Where(p=>p.IsDelete==false)
                    .Include(p => p.Category)
                    .Include(p=>p.Brand)
                    .Include(p=>p.ProductImages)
                    .Include(p=>p.TagProducts)
                    .ThenInclude(tp=>tp.Tag)
                    .OrderBy(p => p.Id)
                    .Where(p => p.Name.ToLower()
                    .Contains(search.ToLower()))
                    
                    .ToList();
            return PartialView("_SearchPartial", products);
        }
    }
}
