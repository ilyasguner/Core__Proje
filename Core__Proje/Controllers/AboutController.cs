using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {

        AboutManager aboutManager = new AboutManager(new EfAboutDal());


        [HttpGet]
        public IActionResult Index()
        {
            var values = aboutManager.TGetById(1);
            return View(values);
        }


        [HttpPost]
        public IActionResult Index(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("Index","Default");
        }
    }
}
