using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Core__Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        
        [Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
        public string Name  { get; set; }

        [Required(ErrorMessage ="Lütfen Soy Adınızı Giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string  UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Resim Yolunu Giriniz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage ="Lütfen Şifreyi Giriniz")]
        public string  Password { get; set; }

        [Required(ErrorMessage ="Lütfen Şifreyi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Lütfen Mail Giriniz")]
        public string EMail { get; set; }

        
        public string UserRole { get; set; }
    }
}
