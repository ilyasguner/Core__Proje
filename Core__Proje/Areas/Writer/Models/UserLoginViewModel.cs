using System.ComponentModel.DataAnnotations;

namespace Core__Proje.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }
        
    }
}
