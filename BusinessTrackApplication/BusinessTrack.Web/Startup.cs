using AutoMapper;
using BusinessTrack.Business.Containers.MicrosoftIoc;
using BusinessTrack.Entities.Concrete;
using BusinessTrack.Web.CustomMiddleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessTrack.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomIdentity();

            services.AddCustomInject();
            services.AddCustomModelFactory();
            services.AddCustomValidator();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc().AddFluentValidation();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //} 
            //else
            //{

            //    app.UseHsts();
            //}
            app.UseExceptionHandler("/Home/Error");
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

            app.UseRouting();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseAuthentication(); //Giriþ yapma iþlemi
            app.UseAuthorization(); //Rol bazlý yetkilendirme.

            app.UseCustomEndpoints();
        }
    }
}
