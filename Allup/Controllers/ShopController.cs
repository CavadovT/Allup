using Allup.DAL;
using Allup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products =await _context.Products
                .Where(p=>p.IsDelete==false)
                .Take(10)
                .Include(p => p.Category)
                .Include(p=>p.ProductImages)
                .ToListAsync();
            return View(products);
            
        }
    }
}
