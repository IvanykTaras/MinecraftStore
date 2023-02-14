using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MinecraftStore.Data.Service;
using MinecraftStore.Models;
using System.Security.Policy;

namespace MinecraftStore.Controllers 
{
    [Authorize]
    public class AccountController : Controller
    {     
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }



        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new LoginUser
                {
                    ReturnUrl = returnUrl
                });
            }
            return Redirect("/");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(loginUser.Name);
                
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user,
                    loginUser.Password, false, false)).Succeeded);
                    {

                        return Redirect(loginUser?.ReturnUrl ?? "/");
                    }
                }
            }

            ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
            
            return View(loginUser);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new LoginUser
                {
                    ReturnUrl = returnUrl
                });
            }
            return Redirect("/");
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(LoginUser loginUser)
        {
            if (ModelState.IsValid) {

                IdentityUser user = new IdentityUser(loginUser.Name);
                var result = await _userManager.CreateAsync(user, loginUser.Password);
                //Error
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return View(loginUser);
                }


                await _userManager.AddToRoleAsync(user, "User");

                await _signInManager.SignOutAsync();
                if ((await _signInManager.PasswordSignInAsync(user,
                loginUser.Password, false, false)).Succeeded) ;
                {
                    return Redirect(loginUser?.ReturnUrl ?? "/");
                }

            }

            return View(loginUser);
        }



        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
