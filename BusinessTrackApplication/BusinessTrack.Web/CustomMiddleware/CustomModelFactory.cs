using BusinessTrack.Web.Areas.Admin.Factories;
using BusinessTrack.Web.Areas.Member.Factories;
using BusinessTrack.Web.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessTrack.Web.CustomMiddleware
{
    public static class CustomModelFactory
    {
        public static void AddCustomModelFactory(this IServiceCollection services)
        {
            services.AddScoped<IExigencyModelFactory, ExigencyModelFactory>();
            services.AddScoped<IAssignmentModelFactory, AssignmentModelFactory>();
            services.AddScoped<INotificationModelFactory, NotificationModelFactory>();
            services.AddScoped<IWorkModelFactory, WorkModelFactory>();
            services.AddScoped<IReportModelFactory, ReportModelFactory>();
            services.AddScoped<IAppUserModelFactory, AppUserModelFactory>();
        }
    }
}
