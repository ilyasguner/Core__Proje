using System.ComponentModel.DataAnnotations;

namespace Core__Proje.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage ="Ad Alanı Boş Bırakılamaz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Alanı Boş Bırakılamaz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Alanı Boş Bırakılamaz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Resim Yolu Belirtilmeli")]
        public string PictureUrl { get; set; }

        [Required(ErrorMessage ="Resim Seçiniz Lütfen")]
        public IFormFile Picture { get; set; }
    }
}
