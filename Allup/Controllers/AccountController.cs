using Allup.DAL;
using Allup.Helpers;
using Allup.Models;
using Allup.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Allup.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager,AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            User user = new User
            {
                FullName = registerVM.FullName,
                UserName = registerVM.Username,
                Email = registerVM.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }
          
            await _userManager.AddToRoleAsync(user, UserRoles.Member.ToString());

            if (registerVM.Subscribe == true) 
            {
                Subscriber subscriber = new Subscriber { Email=user.Email };
                await _context.Subscribers.AddAsync(subscriber);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "home");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM, string ReturnUrl)
        {
            if (!ModelState.IsValid) return View();
            User user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user == null) return View("Error");

            SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, isPersistent: true, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "account blocked");
                return View(loginVM);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "email or password invalided");
                return View(loginVM);
            }
            await _signInManager.SignInAsync(user, isPersistent: true);
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var item in roles)
            {
                if (item == "Admin")
                {
                    return RedirectToAction("index", "dashboard", new { area = "AdminPanel" });
                }
            }
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("index", "home");
        }
        /// <summary>
        /// Logout Action
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

        /// <summary>
        /// Create role Action
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
                }
            }
            return RedirectToAction("index", "home");
        }

    }
}
