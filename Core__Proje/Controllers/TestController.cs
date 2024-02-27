using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
