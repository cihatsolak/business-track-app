using BusinessTrack.Web.Areas.Admin.Models.Assignments;
using BusinessTrack.Web.Areas.Admin.Models.Exigencies;
using BusinessTrack.Web.Areas.Admin.Validators;
using BusinessTrack.Web.Areas.Member.Models.Reports;
using BusinessTrack.Web.Areas.Member.Validators;
using BusinessTrack.Web.Models.Users;
using BusinessTrack.Web.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessTrack.Web.CustomMiddleware
{
    public static class CustomValidator
    {
        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<ExigencyViewModel>, ExigencyViewModelValidator>();
            services.AddSingleton<IValidator<AssignmentViewModel>, AssignmentViewModelValidator>();
            services.AddSingleton<IValidator<ReportAddViewModel>, ReportAddViewModelValidator>();
            services.AddSingleton<IValidator<AppUserViewModel>, AppUserViewModelValidator>();
            services.AddSingleton<IValidator<AppUserSignInModel>, AppUserSignInModelValidator>();
        }
    }
}
