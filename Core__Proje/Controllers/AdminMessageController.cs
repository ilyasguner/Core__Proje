using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterDal());

        string p = "admin@gmail.com";

        public IActionResult ReceiverMessageList()
        {
            
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values = writerMessageManager.TGetById(id);
            return View(values);
        }

        public IActionResult AdminMessageDelete(int id)
        {
            var values = writerMessageManager.TGetById(id);
            writerMessageManager.TDelete(values);
            if (values.SenderName != null)

            {

                return RedirectToAction("ReceiverMessageList");

            }
            return RedirectToAction("SenderMessageList");
            
        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage message)
        {
            message.SenderName = "admin";
            message.Sender = "admin@gmail.com";
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());//mesaj yazıldığı anda tarihi otomatik atıyoruz
            Context c = new Context();
            var username = c.Users.Where(x => x.Email == message.Recevier).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            message.RecevierName = username;
            writerMessageManager.TAdd(message);
            return RedirectToAction("SenderMessageList");
        }
    }
}
