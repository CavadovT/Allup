﻿using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Allup.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        /// <summary>
        /// constroctor dependes injection
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="roleManager"></param>
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string search)
        {
            var users = search == null ?
                await _userManager.Users.ToListAsync() :
                await _userManager.Users
                .Where(u => u.FullName.ToLower().Contains(search.ToLower())).ToListAsync();

            return View(users);
        }


        public async Task<IActionResult> Update(string Id)
        {
            
            User user = await _userManager.FindByIdAsync(Id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = await _roleManager.Roles.ToListAsync();
            RoleVM roleVM = new RoleVM
            {
                FullName = user.FullName,
                Roles = roles,
                UserRoles = userRoles,
                UserId = user.Id,
            };
            return View(roleVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(List<string> roles, string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, roles);


            return RedirectToAction("index");
        }
    }
}
