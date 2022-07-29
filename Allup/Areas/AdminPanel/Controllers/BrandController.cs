using Allup.DAL;
using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allup.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Read action for brand
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(int page = 1, int take = 5)
        {
            ViewBag.Page = page;
            List<Brand> brands = await _context.Brands.Where(b=>b.IsDeleted==false).Skip((page - 1) * take).Take(take).ToListAsync();
            int pageCount = await PageCount(take);
            PaginationVM<Brand> pagVM = new PaginationVM<Brand>(brands, await PageCount(take), page);
            return View(pagVM);
        }
        private async Task<int> PageCount(int take)
        {
            List<Brand> dbBrands = await _context.Brands.Where(b=>b.IsDeleted==false).ToListAsync();
            if (dbBrands.Count() % take == 0)
            {
                return (int)Math.Ceiling((decimal)(dbBrands.Count() / take));
            }
            else
            {
                return (int)Math.Ceiling((decimal)(dbBrands.Count() / take)) + 1;
            }
        }
        /// <summary>
        /// create brand get 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// create brand action post
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            bool ExistNameBrand =await _context.Brands.Where(b=>b.IsDeleted==false).AnyAsync(b => b.Name.Trim().ToLower() == brand.Name.Trim().ToLower());
            if (ExistNameBrand)
            {
                ModelState.AddModelError("Name", "with this name brand allready exist");
                return View();
            }

            Brand newBrand = new Brand
            {
                Name = brand.Name,
                CreatedAt = DateTime.Now,
            };

            await _context.Brands.AddAsync(newBrand);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }
        /// <summary>
        /// delete brand action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Brand brand = await _context.Brands.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(b=>b.Id==id);
            if (brand == null) return NotFound();
            brand.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        /// <summary>
        /// Detail action for brand
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Brand brand = await _context.Brands.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(b => b.Id == id);
            ViewBag.CountProduct= await _context.Products.Where(p=>p.IsDelete==false).Where(p=>p.BrandId==id).CountAsync();
            if (brand == null) return NotFound();
            return View(brand);
        }
        /// <summary>
        /// Get action for Brand update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Update(int? id) 
        {
            if (id == null) return NotFound();
            Brand dbbrand =await _context.Brands.Where(b=>b.IsDeleted==false).FirstOrDefaultAsync(b=>b.Id==id);
            if (dbbrand == null) return NotFound();
            return View(dbbrand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Brand brand) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Brand dbbrand =await _context.Brands.Where(b=>b.IsDeleted==false).FirstOrDefaultAsync(c => c.Id == brand.Id);
            if (dbbrand == null)
            {
                return View();
            }
            else
            {
                Brand dbBrandName = _context.Brands.Where(b=>b.IsDeleted==false).FirstOrDefault(c => c.Name.Trim().ToLower() == brand.Name.Trim().ToLower());

                if (dbBrandName != null)
                {
                    if (dbBrandName.Name.Trim().ToLower() != dbbrand.Name.Trim().ToLower())
                    {
                        ModelState.AddModelError("Name", "with this name category allready exist");
                        return View();
                    }
                }
                dbbrand.Name = brand.Name;
                dbbrand.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("index");
        }

    }
}
