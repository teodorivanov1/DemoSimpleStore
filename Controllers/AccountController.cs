using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Enums;
using SimpleStoreWeb.ViewModels;
using System;
using System.Threading.Tasks;


namespace SimpleStoreWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "app");
            }

            return View();
        }

        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "app");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInResult = null;
            if (ModelState.IsValid)
            {
                signInResult = await signInManager.PasswordSignInAsync(
                                       model.Username,
                                       model.Password,
                                       model.RememberMe,
                                       lockoutOnFailure: false);
                if (signInResult.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(model.Username);
                    if (await userManager.IsInRoleAsync(user, ApplicationRoles.Administrator.ToString()))
                    {
                        return RedirectToAction("index", "admin");
                    }
                    return RedirectToAction("index", "products");
                }
            }

            ModelState.AddModelError("", "Failed to login");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Username
                };

                IdentityResult createUser = await userManager.CreateAsync(user, model.Password);

                if (createUser.Succeeded)
                {
                    var assignRoleResult = await userManager
                        .AddToRoleAsync(user, ApplicationRoles.User.ToString());
                    if (assignRoleResult.Succeeded)
                    {
                        return View("RedirectPage");
                    }
                    else
                    {
                        await userManager.DeleteAsync(user);
                    }
                }

                ModelState.AddModelError("", "Грешка при регистрацията на потребителя. Моля опитайте отново.");
                return View();
            }

            ModelState.AddModelError(string.Empty, "Невалидни данни.");
            return View();
        }
    }
}
