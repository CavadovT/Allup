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
    //[Authorize]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public CategoryController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _env = environment;
        }
        /// <summary>
        /// Admin Category index action
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            ViewBag.Page = page;
            List<Category> categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            List<Category> maincat = new List<Category>();
            List<Category> subcat = new List<Category>();
            foreach (var category in categories)
            {
                if (category.ParentId == null)
                {
                    maincat.Add(category);
                }
                else
                {
                    subcat.Add(category);
                }
            }
            int pageCount = PageCount(maincat, take);
            int pageCountsub = PageCount(subcat, take);
            CategoryVM<Category> pagVM = new CategoryVM<Category>(maincat.Skip((page - 1) * take).Take(take).ToList(), subcat.Skip((page - 1) * take).Take(take).ToList(), pageCount, pageCountsub, page);
            return View(pagVM);


        }
        private int PageCount(List<Category> cat, int take)
        {

            if (cat.Count() % take == 0)
            {
                return (int)Math.Ceiling((decimal)(cat.Count() / take));
            }
            else
            {
                return (int)Math.Ceiling((decimal)(cat.Count() / take)) + 1;
            }
        }
        /// <summary>
        /// create action get 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();

        }
        /// <summary>
        /// create action post
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {


            Category dbCategory = await _context.Categories.FindAsync(category.Id);

            Category newCategory = new Category();

            if (category.Name == null)
            {
                ModelState.AddModelError("Name", "name of Category can't be empty!");
                return View();
            }
            bool existCategoryName = _context.Categories.Where(c => c.IsDeleted != true).Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (existCategoryName)
            {
                ModelState.AddModelError("Name", "This category is already exist");
                return View();
            }

            if (category.Photo == null)
            {
                ModelState.AddModelError("Image", "Select Image");
                return View();
            }

            if (!category.Photo.IsImage())
            {
                ModelState.AddModelError("Image", "Only Image Files");
                return View();
            }
            if (category.Photo.ValidSize(1000))
            {
                ModelState.AddModelError("Image", "Oversize");
                return View();
            }
            newCategory.ImgUrl = category.Photo.SaveImage(_env, "assets/images");

            newCategory.Name = category.Name;

            newCategory.CreatedAt = DateTime.Now;


            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }
        /// <summary>
        /// sub category create action get
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CreateSub()
        {
            ViewBag.MainCategories = new SelectList(await _context.Categories.Where(c => c.ParentId == null).ToListAsync(), "Id", "Name");
            return View();
        }
        /// <summary>
        /// create sub category action post
        /// </summary>
        /// <param name="subCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSub(Category subCategory)
        {
            ViewBag.MainCategories = new SelectList(await _context.Categories.Where(c => c.ParentId == null).ToListAsync(), "Id", "Name");
            if (subCategory.Name == null)
            {
                ModelState.AddModelError("Name", "name of Category can't be empty!");
                return View();
            }
            bool existCategoryName =await _context.Categories.Where(c => c.IsDeleted != true).AnyAsync(c => c.Name.ToLower().Trim() == subCategory.Name.ToLower().Trim());
            if (existCategoryName)
            {
                ModelState.AddModelError("Name", "This category is already exist");
                return View();
            }

            //bool ExistSubCategoryName = await _context.Categories.Where(c=>c.IsDeleted==false).Where(c => c.ParentId == subCategory.Id).AnyAsync(c => c.Name.ToLower().Trim() == subCategory.Name.ToLower().Trim());

            //if (ExistSubCategoryName)
            //{
            //    ModelState.AddModelError("Name", "The name of subcategory alredy exsist in this main category!!!");
            //    return View();
            //}
            //umuiyen eyni adl kategory yaratmasin

            Category newsubcat = new Category();
            newsubcat.Name = subCategory.Name;
            newsubcat.ParentId = subCategory.Id;
            newsubcat.CreatedAt = DateTime.Now;
            await _context.Categories.AddAsync(newsubcat);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }
        /// <summary>
        /// update main category get
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null) return NotFound();
            Category category = await _context.Categories.Where(c => c.IsDeleted == false).FirstOrDefaultAsync(c => c.Id == Id);
            if (category == null) return NotFound();
            return View(category);
        }
        /// <summary>
        /// update main category post
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category dbCategory = _context.Categories.Where(c=>c.IsDeleted==false).FirstOrDefault(c => c.Id == category.Id);
            if (dbCategory == null)
            {
                return View();
            }
            else
            {
                Category dbCategoryName = _context.Categories.FirstOrDefault(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());

                if (dbCategoryName != null)
                {
                    if (dbCategoryName.Name.Trim().ToLower() != dbCategory.Name.Trim().ToLower())
                    {
                        ModelState.AddModelError("Name", "This category is already exist");
                        return View();
                    }
                }
                if (category.Photo == null)
                {
                    dbCategory.ImgUrl = dbCategory.ImgUrl;
                }
                else
                {
                    if (!category.Photo.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Choose the photo");
                        return View();
                    }
                    if (category.Photo.ValidSize(200))
                    {
                        ModelState.AddModelError("Photo", "oversize");
                        return View();
                    }
                    string oldPhoto = dbCategory.ImgUrl;
                    string path = Path.Combine(_env.WebRootPath, "assets/images", oldPhoto);

                    Helper.DeleteImage(path);

                    dbCategory.ImgUrl = category.Photo.SaveImage(_env, "assets/images");

                }
                dbCategory.Name = category.Name;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("index");

        }
        /// <summary>
        /// sub cat update get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateSub(int? id)
        {
            if (id == null) return NotFound();
            ViewBag.MainCat = new SelectList(await _context.Categories.Where(c => c.IsDeleted == false).Where(c => c.ParentId == null).ToListAsync(), "Id", "Name");
            ViewBag.subId = id;
            Category category = await _context.Categories.Where(c => c.IsDeleted == false).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);

        }
        /// <summary>
        /// sub category update post
        /// </summary>
        /// <param name="subcategory"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSub(Category subcategory, int subid)
        {
            ViewBag.MainCat = new SelectList(await _context.Categories.Where(c => c.IsDeleted == false).Where(c => c.ParentId == subcategory.Id).ToListAsync(), "Id", "Name");
            ViewBag.subid = subid;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "error");
                return View();
            }
            Category dbCategorySub = _context.Categories.FirstOrDefault(c => c.Id == subid);
            if (dbCategorySub == null)
            {
                return View();
            }
            else 
            {
                Category dbCategoryName = await _context.Categories.Where(c => c.IsDeleted == false).FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == subcategory.Name.Trim().ToLower());
                if (dbCategoryName != null)
                {
                    if (dbCategoryName.Name.Trim().ToLower() != dbCategorySub.Name.Trim().ToLower())
                    {
                        ModelState.AddModelError("Name", "This product is already exist!!!");
                        return View();
                    }
                }
                dbCategorySub.ParentId = subcategory.Id;
                dbCategorySub.UpdatedAt = DateTime.Now;
                dbCategorySub.Name = subcategory.Name;
                await _context.SaveChangesAsync();
            }
           
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
            Category dbCategory = await _context.Categories.Where(c => c.IsDeleted == false).FirstOrDefaultAsync(c => c.Id == Id);
            if (dbCategory == null) return NotFound();

            if (dbCategory.ParentId == null)
            {
                List<Category> subcategory = await _context.Categories.Include(c => c.Children).Where(c => c.ParentId == Id).ToListAsync();
                foreach (var category in subcategory)
                {
                    category.IsDeleted = true;
                    category.DeletedAt = DateTime.Now;
                }
                dbCategory.IsDeleted = true;
                string path = Path.Combine(_env.WebRootPath, "assets/images", dbCategory.ImgUrl);

                Helper.DeleteImage(path);
                dbCategory.DeletedAt = DateTime.Now;

            }
            dbCategory.IsDeleted = true;
            dbCategory.DeletedAt = DateTime.Now;

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
            Category dbCategory = await _context.Categories.Where(c => c.IsDeleted == false).FirstOrDefaultAsync(c => c.Id == Id);

            if (dbCategory == null) return NotFound();
            if (dbCategory.ParentId != null)
            {
                ViewBag.ParentName = (await _context.Categories.Where(c => c.IsDeleted == false).Where(c => c.Id == dbCategory.ParentId).FirstOrDefaultAsync()).Name;
            }
            return View(dbCategory);

        }
    }
}
