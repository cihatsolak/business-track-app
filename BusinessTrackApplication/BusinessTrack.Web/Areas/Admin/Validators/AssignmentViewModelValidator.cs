using BusinessTrack.Web.Areas.Admin.Models.Assignments;
using FluentValidation;

namespace BusinessTrack.Web.Areas.Admin.Validators
{
    public class AssignmentViewModelValidator : AbstractValidator<AssignmentViewModel>
    {
        public AssignmentViewModelValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Lütfen bir görev adı giriniz.")
                                .NotNull().WithMessage("Lütfen bir görev adı giriniz.")
                                .Length(3, 50).WithMessage("Görev adı, 3-50 karakter arasında olmalıdır.");

            RuleFor(i => i.Description).NotEmpty().WithMessage("Lütfen bir görev açıklaması giriniz.")
                                       .NotNull().WithMessage("Lütfen bir görev açıklaması giriniz.");

            RuleFor(i => i.ExigencyId).GreaterThanOrEqualTo(1).WithMessage("Lütfen aciliyet durumunu belirtiniz.");
        }
    }
}
