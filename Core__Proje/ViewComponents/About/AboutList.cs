using BusinessLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.About
{
    public class AboutList:ViewComponent
    {

        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        //shared/componenets içindeki bu componenet ile aynı addaki klasörde bulunan cshtml uzantılı dosyaya gidiyor ve 
        //o html sayfasını çalıştırıyor
        public IViewComponentResult Invoke()
        {
            var values = aboutManager.TGetList();
            return View(values);
        }
    }
}
