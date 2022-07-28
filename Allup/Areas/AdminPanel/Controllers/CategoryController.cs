using Allup.DAL;
using Allup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    //[Authorize]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Admin Category index action
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.Include(c => c.Children).ToListAsync());
        }


        public IActionResult Create() 
        {
            return View();
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category) 
        {
            return RedirectToAction("index");
        }

        /// <summary>
        /// Admin category delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null) return NotFound();
            Category dbCategory = await _context.Categories.Include(c => c.Children).FirstOrDefaultAsync(c => c.Id == Id);
            if (dbCategory == null) return NotFound();

            if (dbCategory.ParentId == null)
            {
                List<Category> subcategory = await _context.Categories.Include(c => c.Children).Where(c => c.ParentId == Id).ToListAsync();
                foreach (var category in subcategory)
                {
                    dbCategory.Children.Remove(category);
                }
                _context.Categories.Remove(dbCategory);

            }
            else
            {
                List<Category> categories = dbCategory.Children;
                categories.Remove(dbCategory);
                _context.Categories.Remove(dbCategory);

            }

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        /// <summary>
        /// Detail Category Action
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int? Id)
        {

            if (Id == null) return NotFound();
            Category category = await _context.Categories.Include(c => c.Children).FirstOrDefaultAsync(c => c.Id == Id);

            if (category == null) return NotFound();
            if (category.ParentId != null)
            {
                ViewBag.ParenName = (await _context.Categories.Include(c => c.Children).Where(c => c.Id == category.ParentId).FirstOrDefaultAsync()).Name;
            }
            return View(category);

        }
    }
}
