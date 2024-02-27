using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        //bu sınıfta kodları yazıyoruz
        //shared altındaki components klasöründe de bu sınıfla aynı adda kalasö oluşturup view ekliyoruz
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }
    
    }
}
