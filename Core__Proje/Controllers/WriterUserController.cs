using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core__Proje.Controllers
{   //Ajax
    public class WriterUserController : Controller
    {
        WriterUserManager writerUserManager = new WriterUserManager(new EfWriterUserDal());

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(writerUserManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddUser(WriterUser p)
        {
            writerUserManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
