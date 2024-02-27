using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = writerMessageManager.GetListReceiverMessage(p);
            return View(messagelist);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = writerMessageManager.GetListSenderMessage(p);
            return View(messagelist);
        }
        
        [HttpGet]
        [Route("SenderMessageDetails/{id}")]
        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }
       
        [HttpGet]
        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();//sayfa açılma isteği
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {//yeni bir mesaj gönderildiğinde yani post olduğunda çalışcak method                                  
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                string mail = values.Email;
                string name = values.Name + " " + values.Surname;
                p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                p.Sender = mail;//veri tabanında sende olarak sadece mailinin tutuyoruz
                p.SenderName = name;
                Context c = new Context();
                var receiverNameSurname = c.Users.Where(x => x.Email == p.Recevier).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
                p.RecevierName = receiverNameSurname;
                writerMessageManager.TAdd(p);
                return RedirectToAction("SenderMessage", "Message");//Message içindeki SenderMessage sayfasına yönlendirme                                               
        }
    }
}
