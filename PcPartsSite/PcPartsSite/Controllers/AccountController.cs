using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PcPartsSite.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            IdentityUser signedUser = await _userManager.FindByEmailAsync(login.Email);
            var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, login.Password, login.RememberMe, false);

            if (result.Succeeded)
            {
                if (String.IsNullOrWhiteSpace(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                ModelState.AddModelError("", "Error Logging In");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (String.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            IdentityUser user = new IdentityUser();
            user.Email =  model.Email;
            user.UserName = model.Email;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    if (!(error.Code == "DuplicateUserName")) //removes error referring to usernamee because email is used as username
                    {
                         ModelState.AddModelError("", error.Description);
                    }                   
                }

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

            
           
        }

    }
}