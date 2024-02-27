using BusinessLayer.Concreate;
using Core__Proje.Areas.Writer.Models;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/[Controller]/[action]")]
    public class ProfileController : Controller
    {

        public readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {         
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.Picture!=null)
            {   //resim yolunu alıp kaydetme kodları
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
