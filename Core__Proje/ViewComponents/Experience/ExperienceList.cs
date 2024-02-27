using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {

        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IViewComponentResult Invoke()
        {
            var values = experienceManager.TGetList();
            return View(values);
        }

    }
}
