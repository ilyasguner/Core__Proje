using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core__Proje.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var experience = experienceManager.TGetById(ExperienceID);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetById(id);
            experienceManager.TDelete(values);
            return NoContent();
        }
    }
}
