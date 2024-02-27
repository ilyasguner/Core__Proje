using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Core__Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            string api = "55fc84c41bdede2ba4bc962332e0f49f";
            string connection ="https://api.openweathermap.org/data/2.5/weather?q=London&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = XDocument.Load(connection);

            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            Context c = new Context();
            ViewBag.v1 = c.writerMessages.Where(x=>x.Recevier==values.Email).Count();//gelen mesaj sayısı
            ViewBag.v2 = c.Announcements.Count();//duyuru sayısı
            ViewBag.v3 = c.Users.Count();//toplam sistem kullanıcı
            ViewBag.v4 = c.writerMessages.Where(x=>x.Sender==values.Email).Count();//gönderilen mesaj sayısı
            return View();
        }
    }
}

/*
    https://api.openweathermap.org/data/2.5/weather?q=London&mode=xml&lang=tr&units=metric&appid=55fc84c41bdede2ba4bc962332e0f49f
 */
