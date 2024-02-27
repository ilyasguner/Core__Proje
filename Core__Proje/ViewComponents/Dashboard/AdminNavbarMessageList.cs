using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterDal());

        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(p).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList();
            return View(values);
        }

    }
}
