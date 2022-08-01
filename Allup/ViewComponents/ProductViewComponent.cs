using Allup.DAL;
using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {

        private readonly AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int skip)
        {
            List<Product> products =await _context.Products
                .Where(p=>p.IsDelete==false)
                .Include(p=>p.ProductImages)
                .Skip(skip).Include(p => p.Category).ToListAsync();
            return View(await Task.FromResult(products));
        }
    }
}
