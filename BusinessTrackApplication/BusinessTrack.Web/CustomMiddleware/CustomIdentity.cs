using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessTrack.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BusinessTrack.Web.CustomMiddleware
{
    public static class CustomIdentity
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddDbContext<BusinessTrackContext>();

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<BusinessTrackContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "JobTrackingSystemCache";
                options.Cookie.SameSite = SameSiteMode.Strict; //Strict : Cookie başka web sayfalarında paylaşılmasın.
                options.Cookie.HttpOnly = true; //İlgili kullanıcı document.cookie yazar cookie'ye ulaşamasın.
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); //Bu cookie 30 dakika ayakta kalsın.
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; //İstek ne şekilde ise öyle davran. Https ya da Http farketmez.

                options.LoginPath = new PathString("/Account/SignIn");
                options.LogoutPath = new PathString("/Account/SignOut");
            });
        }
    }
}
