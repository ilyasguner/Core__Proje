using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IViewComponentResult Invoke()
        {
            var values = socialMediaManager.TGetList();
            return View(values);
        }
    }
}
