using BusinessLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Skill
{
    public class SkillList:ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public IViewComponentResult Invoke()
        {
            var values = skillManager.TGetList();
            return View(values);
        }
    }
}
