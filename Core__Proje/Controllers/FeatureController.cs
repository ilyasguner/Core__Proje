using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {

        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());


        [HttpGet]
        public IActionResult Index()
        {
            var values = featureManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }

    }
}
