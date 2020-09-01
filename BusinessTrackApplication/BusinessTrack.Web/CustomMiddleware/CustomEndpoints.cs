using Microsoft.AspNetCore.Builder;

namespace BusinessTrack.Web.CustomMiddleware
{
    public static class CustomEndpoints
    {
        public static void UseCustomEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Account}/{action=SignIn}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=SignIn}/{id?}",
                    defaults: new { controller = "Account", action = "SignIn" });
            });
        }
    }
}
