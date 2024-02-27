using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace Core__Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());

        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var values = testimonialManager.TGetById(id);
            testimonialManager.TDelete(values);
            return View();
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var values = testimonialManager.TGetById(id);
            return View(values);           
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial t)
        {
            testimonialManager.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
