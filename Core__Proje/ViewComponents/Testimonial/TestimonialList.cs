using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace Core__Proje.ViewComponents.Testimonial
{
    public class TestimonialList:ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());

        public IViewComponentResult Invoke()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
    }
}
