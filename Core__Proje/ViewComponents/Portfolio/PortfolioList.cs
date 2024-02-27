using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core__Proje.ViewComponents.Portfolio
{
    public class PortfolioList:ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IViewComponentResult Invoke()
        {
            var rules = portfolioManager.TGetList();
            return View(rules);
        }

    }
}
