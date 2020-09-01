using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BusinessTrack.Web.Models.Users
{
    public class AppUserViewModel : BaseEntityModel<int>
    {
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "E-Posta Adresi")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        public string Picture { get; set; }
        [Display(Name = "Resim dosyası seçiniz")]
        public IFormFile ProfilePictureFile { get; set; }

        public bool EditProfile { get; set; } //makeshift
    }
}
