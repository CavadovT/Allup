using Allup.DAL;
using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Allup.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        

        public FooterViewComponent(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterVM footerVM = new FooterVM();
            footerVM.Bio = await _context.Bios.FirstOrDefaultAsync();
            footerVM.SubscripeSection = await _context.SubscripeSections.FirstOrDefaultAsync();
            footerVM.ContactUs = await _context.ContactUs.FirstOrDefaultAsync();

            return View(await Task.FromResult(footerVM));

        }
    }
}
