using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartHome_Project.ViewModels;

namespace Cuba_Staterkit.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager<IdentityUser> SignInManager { get; }
        public UserManager<IdentityUser> UserManager { get; }

        private readonly Context Context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, Context _context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = _context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM registerUserVM)
        {
            if (ModelState.IsValid)
            {
                IdentityUser userDbModel = new IdentityUser
                {
                    UserName = registerUserVM.Email,
                    Email = registerUserVM.Email,
                    PasswordHash = registerUserVM.Password

                };

                IdentityResult result = await UserManager.CreateAsync(userDbModel, registerUserVM.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(userDbModel, true);

                    await Context.SaveChangesAsync();

                    return RedirectToAction("Index", "Dashboard");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("element", item.Description);
                    }
                }
            }
            return View(registerUserVM);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM loginUserVM)
        {
            if (ModelState.IsValid)
            {
                IdentityUser userModelfromDb = await UserManager.FindByEmailAsync(loginUserVM.Email);

                if (userModelfromDb != null)
                {
                    bool exist = await UserManager.CheckPasswordAsync(userModelfromDb, loginUserVM.Password);

                    if (exist)
                    {
                        await SignInManager.SignInAsync(userModelfromDb, loginUserVM.RememberMe);
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }

            ModelState.AddModelError("", "Wrong Username or Password");
            return View(loginUserVM);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
