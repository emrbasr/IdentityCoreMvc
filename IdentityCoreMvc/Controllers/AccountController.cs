﻿using IdentityCoreMvc.Identites;
using IdentityCoreMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCoreMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyUser> userManager;
        private readonly SignInManager<MyUser> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public AccountController(UserManager<MyUser> userManager
                                , SignInManager<MyUser> signInManager
                                , RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
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
            var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, true, true);
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



        [HttpGet]

        public async Task<IActionResult> Register()
        {
            RegisterVM registerVM = new RegisterVM();
            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            MyUser user = new MyUser
            {
                Email = registerVM.Email,
                TcNo = registerVM.TcNo,
                UserName = registerVM.UserName

            };

            var result = await userManager.CreateAsync(user, registerVM.Password);
            // Eger Roller Tablosunda Uye Rolu yoksa Olusturacaktir

            if (await roleManager.FindByNameAsync("Uye") == null)
            {
                IdentityRole<int> role = new IdentityRole<int>("Uye");

                await roleManager.CreateAsync(role);
            }

            await userManager.AddToRoleAsync(user, "Uye");
            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault();
                ModelState.AddModelError("", error.Description);
                return View(registerVM);
            }


            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);


            /*
             saravap672@dewareff.com
             123456789987654321
            Connect to SendGrid's SMTP server at smtp.sendgrid.net and use port 587.
             */

            string message = $@"<!DOCTYPE html>  
                            <html>  
                            <head>  
                                <title></title>  
                                <meta charset=""utf-8"" />  
                                <style>  
                                    table, th, td {{  
                                border: 1px solid black;  
                            }}  
                                </style>  
                            </head>  
                            <body>  
                                   <br />  
                                <table width=""50%"">  
                                    <tr>  
                                        <td align=""center"" style=""background-color:yellow"">  
                                            <span style=""font-size:25px;"">   Welcome To C# Corner  </span>  
                                            <br />  
                                            <br />  
                                        </td>  
              
                                    </tr>  
          
                                    <tr align=""center"">  
                                        <td>  
                                            <br />  
                                            <br />  
                                            Dear [newusername]  
                                            <br />  
                                            <br />  
                                           Thank you for registering with us!  
                                            <br />  
                                            <a href='https://localhost:7183/MailKontrol/?uid={user.Id}&code={token}'>  
                                                Click here to Login  
                                            </a>  
  
                                            Regards,  
                                            <br />  
                                            <br />  
                                        </td>  
                                        </tr>  
                            <tr>  
                                        <td align=""center"" style=""background-color:yellow"">  
                                            <br />  
                                            <br />  
                                            <span style=""font-size:15px;text-decoration:underline"">   Share your knowledge   </span>  
                                            <br />  
                                            <span style=""font-size:20px;"">   <i>If you have knowledge, let others light their candles in it - Margaret Fuller    </span>  
                                            <br />  
                                            <br />  
                                        </td>  
  
                                    </tr>  
  
                                </tr>  
          
  
                                </table>  
                            </body>  
                            </html>  ";
            EmailHelper emailHelper = new EmailHelper();
            var sonuc = await emailHelper.SendEmail("siyahbeyazz@gmail.com", message);
            if (sonuc)
            {
                return RedirectToAction("Index", "Home");

            }

            ModelState.AddModelError("", "Beklenmeyen bir hata olustu . Lutfen daha sonra tekrar deneyiniz");
            return View(registerVM);
        }


        [Route("MailKontrol")]
        public async Task<IActionResult> ConfirmEmail(string uid, string code)
        {
            ConfirmEmailModel model = new ConfirmEmailModel();
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(code))
            {
                var user = await userManager.FindByIdAsync(uid);
                code = code.Replace(' ', '+');

                model.Email = user.Email;
                var result = await userManager.ConfirmEmailAsync(user, code);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var error = result.Errors.FirstOrDefault();
                    model.ErrorDescription = error.Description;
                    model.HasError = true;
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }

            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
