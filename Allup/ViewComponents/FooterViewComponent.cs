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
        private readonly UserManager<User> _userManager;

        public FooterViewComponent(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
