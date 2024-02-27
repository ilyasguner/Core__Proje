using Core__Proje.Areas.Writer.Models;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[Controller]/[action]")]
    public class LoginController : Controller
    {

        private readonly SignInManager<WriterUser> _signInManager;

        public LoginController(SignInManager<WriterUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if(ModelState.IsValid)//giriline verilerin doğruluğu kontrol ediliyor
            {
                var result =await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new { area="Writer"});
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı Adı veya Şifre");
                }
            }

            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


    }
}
