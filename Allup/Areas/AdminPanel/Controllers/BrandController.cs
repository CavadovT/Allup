﻿using Microsoft.AspNetCore.Mvc;

namespace Allup.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}