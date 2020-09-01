using BusinessTrack.Web.Models.Users;
using FluentValidation;

namespace BusinessTrack.Web.Validators
{
    public class AppUserSignInModelValidator : AbstractValidator<AppUserSignInModel>
    {
        public AppUserSignInModelValidator()
        {
            RuleFor(i => i.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.")
                                    .NotNull().WithMessage("Kullanıcı adı boş geçilemez.");

            RuleFor(i => i.Password).NotEmpty().WithMessage("Şifre boş geçilemez.")
                                    .NotNull().WithMessage("Şifre boş geçilemez.");
        }
    }
}
