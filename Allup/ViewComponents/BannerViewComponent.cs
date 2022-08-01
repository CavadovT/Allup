using Allup.DAL;
using Allup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Allup.ViewComponents
{
    public class BannerViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;


        public BannerViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<FeatureBanner> featureBanners=await _context.FeatureBanners.ToListAsync();

            return View(await Task.FromResult(featureBanners));

        }
    }
}
