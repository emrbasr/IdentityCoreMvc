using IdentityCoreMvc.Identites;
using IdentityCoreMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCoreMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyUser> userManager;
        private readonly SignInManager<MyUser> signInManager;

        public AccountController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var login = new LoginModel();
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);

            }

            var user = await userManager.FindByEmailAsync(loginModel.Email);


            if (user == null)
            {
                ModelState.AddModelError("", "Email yada Şifre Hatalidir");
                return View(loginModel);
            }

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Email Onaylanmammistir");
                return View(loginModel);

            }
            var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, true);
            var result2 = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "email yada Şifre Hatalidir");
            return View(loginModel);
        }



        public async Task<IActionResult> LoginOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
