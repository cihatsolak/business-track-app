using BusinessTrack.Web.Areas.Member.Models.Reports;
using FluentValidation;

namespace BusinessTrack.Web.Areas.Member.Validators
{
    public class ReportAddViewModelValidator : AbstractValidator<ReportAddViewModel>
    {
        public ReportAddViewModelValidator()
        {
            RuleFor(i => i.Definition).NotEmpty().WithMessage("Tanım alanı boş geçilemez.")
                                      .NotNull().WithMessage("Tanım alanı boş geçilemez")
                                      .Length(3, 100).WithMessage("Tanım alanı 3-100 karakter içermelidir.");

            RuleFor(i => i.Detail).NotEmpty().WithMessage("Detay alanı boş geçilemez.")
                                      .NotNull().WithMessage("Detay alanı boş geçilemez")
                                      .Length(3, 100).WithMessage("Detay alanı 50-250 karakter içermelidir.");
        }
    }
}
