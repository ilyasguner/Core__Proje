using Core__Proje.Areas.Writer.Models;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core__Proje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[Controller]/[action]")]
    public class RegisterController : Controller
    {
        

        //buradaki UserManger sınıfı identity ile projeye gelen hazır sınıftır kayıt olma işleminde kullanıyoruz
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)//kontrol modelimizden bir nesne türetiyoruz
        {

            if(ModelState.IsValid)//Belirttiğimiz koşullara uygunluğu kontrol ediyor
            {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.SurName,
                    UserName = p.UserName,
                    ImageUrl = p.ImageUrl,
                    Email = p.EMail
                };

                var result = await _userManager.CreateAsync(w, p.Password);//bir asenkronik method ile hesap oluşturuyoruz

                


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login", new { area = "Writer" });
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                return View();
            }
            

            return View();
        }
    }
}
