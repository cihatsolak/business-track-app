using BusinessTrack.Web.Models.Users;
using FluentValidation;

namespace BusinessTrack.Web.Validators
{
    public class AppUserViewModelValidator : AbstractValidator<AppUserViewModel>
    {
        public AppUserViewModelValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Lütfen adınızı giriniz.")
                               .NotNull().WithMessage("Lütfen adınızı giriniz.")
                               .Length(3, 100).WithMessage("Adı alanı 3-100 karakter arası içermelidir.");

            RuleFor(i => i.Surname).NotEmpty().WithMessage("Lütfen soyadınızı giriniz.")
                                   .NotNull().WithMessage("Lütfen soyadınızı giriniz.")
                                   .Length(2, 100).WithMessage("Adı alanı 3-100 karakter arası içermelidir.");

            RuleFor(i => i.Email).NotEmpty().WithMessage("Lütfen e-posta adresinizi giriniz.")
                                  .NotNull().WithMessage("Lütfen e-posta adresinizi giriniz.")
                                  .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");

            When(i => !i.EditProfile, () =>
            {
                RuleFor(i => i.Password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz.")
                                   .NotNull().WithMessage("Lütfen şifrenizi giriniz.");

                RuleFor(i => i.ConfirmPassword).NotEmpty().WithMessage("Lütfen şifrenizi giriniz.")
                                        .NotNull().WithMessage("Lütfen şifrenizi giriniz.")
                                        .Equal(i => i.Password).WithMessage("Girilen şifreler eşleşmiyor.");

                RuleFor(i => i.Username).NotEmpty().WithMessage("Lütfen kullanıcı adınızı giriniz.")
                                        .NotNull().WithMessage("Lütfen kullanıcı adınızı giriniz.")
                                        .Length(5, 20).WithMessage("Kullanıcı adınız 5 ile 20 karakter arası uzunluğa sahip olabilir.");
            });
        }
    }
}
