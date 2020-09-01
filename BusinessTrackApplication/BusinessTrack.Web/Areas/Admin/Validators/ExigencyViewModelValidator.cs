using BusinessTrack.Web.Areas.Admin.Models.Exigencies;
using FluentValidation;

namespace BusinessTrack.Web.Areas.Admin.Validators
{
    public class ExigencyViewModelValidator : AbstractValidator<ExigencyViewModel>
    {
        public ExigencyViewModelValidator()
        {
            RuleFor(i => i.Definition).NotEmpty().WithMessage("Lütfen tanım adını giriniz.")
                                      .NotNull().WithMessage("Lütfen tanım adını giriniz.")
                                      .Length(3, 100).WithMessage("Lütfen 3-100 karakter arasında giriniz.");
        }
    }
}
