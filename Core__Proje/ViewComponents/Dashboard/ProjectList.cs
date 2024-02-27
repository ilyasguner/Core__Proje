using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Dashboard
{
    public class ProjectList:ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }

    }
}
