using IdentityCoreMvc.Identites;
using Microsoft.AspNetCore.Identity;

namespace IdentityCoreMvc.Extentisons
{
    public static class IdentityAyarlari
    {
        public static string TestTurkce(this string str)
        {

            return str.Replace('ç', 'c').ToString();
        }

        public static IServiceCollection AddCookieAyarlari(this IServiceCollection services)
        {


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "Account/Login";
                options.LoginPath = "Account/Logout";
                options.AccessDeniedPath = "Account/AccessDenied";
                options.Cookie.Name = "UskudarCookieWeb";
                options.Cookie.HttpOnly = true;                 //Tarayicidaki diger scriptler cu cookie'yi okuyamasin
                options.Cookie.SameSite = SameSiteMode.Strict;  //Bizim tarayicimiz disinda kullanilmasin

                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true;
            });
            return services;
        }
        public static IServiceCollection AddIdentityAyarlari(this IServiceCollection services)
        {

            // Burasi IOC Container 'a Identity eklemesini soyluyoruz
            services.AddIdentity<MyUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<MyIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                #region Password Kurallari
                //Olusacak sifrenin icerisinde rakam olsunmu ?
                options.Password.RequireDigit = false;
                //Kcuk hafr zorunlulugu olsun mu 
                options.Password.RequireLowercase = false;

                //Buyuk harf olsun mu 
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                //Password uzunlugu ne kadar olsun
                options.Password.RequiredLength = 3;

                #endregion


                #region User ile ilgili options'lar
                //Girilen email uniqe olsun mu
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = @"abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@";

                #endregion


                #region Diger ayarlar :SignIn , LockOut

                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Lockout.AllowedForNewUsers = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 2;

                #endregion


            });

            return services;
        }

    }
}
