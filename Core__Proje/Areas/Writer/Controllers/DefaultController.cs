using BusinessLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles ="Writer")]
    public class DefaultController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());

        public IActionResult Index()
        {
            var values = announcementManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement announcement = announcementManager.TGetById(id);
            return View(announcement);
        }
    }
}
