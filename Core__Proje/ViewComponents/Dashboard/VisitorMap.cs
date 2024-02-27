using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Dashboard
{
    public class VisitorMap:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
