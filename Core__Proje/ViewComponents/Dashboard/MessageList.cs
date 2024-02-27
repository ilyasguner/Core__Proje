using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
