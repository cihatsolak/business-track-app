using BusinessTrack.Business.Concrete;
using BusinessTrack.Business.Interfaces;
using BusinessTrack.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using BusinessTrack.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessTrack.Business.Containers.MicrosoftIoc
{
    public static class CustomIoCInject
    {
        public static void AddCustomInject(this IServiceCollection services)
        {
            //Data Access
            services.AddScoped<IAssignmentDal, EfAssignmentRepository>();
            services.AddScoped<IExigencyDal, EfExigencyRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();
            services.AddScoped<ILoggerDal, EfLoggerRepository>();

            //Business
            services.AddScoped<IAssignmentService, AssignmentManager>();
            services.AddScoped<IExigencyService, ExigencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<ILoggerService, LoggerManager>();
        }
    }
}
