using Allup.DAL;
using Allup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            homeVM.Categories = await _context.Categories.ToListAsync();
            homeVM.SliderContents = await _context.SliderContents.ToListAsync();
            homeVM.Banners = await _context.Banners.ToListAsync();
            homeVM.Brands= await _context.Brands.ToListAsync();
            homeVM.Products=await _context.Products.Include(p=>p.Category).Include(p=>p.ProductImages).ToListAsync();
            homeVM.Blogs=await _context.Blogs.OrderByDescending(b=>b.Id).Skip(3).ToListAsync();
            homeVM.Testonominal = await _context.Testonominals.FirstOrDefaultAsync();
           
            return View(homeVM);
        }
    }
}
