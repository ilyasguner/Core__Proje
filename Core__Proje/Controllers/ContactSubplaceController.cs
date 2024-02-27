using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Controllers
{
    public class ContactSubplaceController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        [HttpGet]
        public IActionResult Index()
        {
            var values = contactManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}
