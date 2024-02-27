using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core__Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();//get list ile veri tabanından veiyi çekiyoruz
            return View(values);//values ile view oluşturduğumuz view sayfasına atıyoruz ki orada kullanalım
        }

        [HttpGet]
        public IActionResult AddPortfolio()//sayfa normal açılmada
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)//veri tabanına veri atarken kullanımı
        {
            PortfolioValidator validations = new PortfolioValidator();//sınıfta yazdığımız kuralları alıyoruz
            ValidationResult results = validations.Validate(portfolio);//bu kuralların uygulanması için nesne oluşturduk

            if(results.IsValid)//eğer bütün doğrulamaları geçtiyse 
            {
                if (portfolio.Value<100)
                {
                    portfolio.Status = false;
                }
                else
                {
                    portfolio.Status = true;
                }
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)//hataları tek tek yazdırıyoruz
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = portfolioManager.TGetById(id);
            portfolioManager.TDelete(value);
            return View();
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Düzenleme";
            var values = portfolioManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);
            if(results.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
