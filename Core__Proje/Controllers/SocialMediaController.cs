using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IActionResult Index()
        {
            var values = socialMediaManager.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteSocialMedia(int id)
        {
            var values = socialMediaManager.TGetById(id);
            socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values = socialMediaManager.TGetById(id);
            return View(values);
        }


        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            socialMediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
