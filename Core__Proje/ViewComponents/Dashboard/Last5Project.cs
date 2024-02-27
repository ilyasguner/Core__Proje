using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Dashboard
{
    public class Last5Project:ViewComponent
    {

        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList().OrderByDescending(x => x.PortfolioID).Take(5).ToList();
            return View(values);
        }

    }
}
