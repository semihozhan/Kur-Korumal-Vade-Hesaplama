using ExchangeRate.Models;
using ExchangeRate.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ExchangeRate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() 
        {
            string getDAte = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var exchangeRate =  new GetDateandExchangeRateList
            (
                    new GetExchangeRateStart
                    {
                        BuyingExchangeDate = getDAte,
                        BuyingExchangeRate = GetDateExchange.GetExchangeRate(getDAte)
                    },
                 new GetExchangeRateFinish
                 {
                     BuyingExchangeDate = getDAte,
                     BuyingExchangeRate = GetDateExchange.GetExchangeRate(getDAte)
                 }
            );

            return View("Index", exchangeRate);
        }
        [HttpPost]
        public IActionResult Index(ExchangeFormDate exchangeFormDate)
        {
            var exchangeRate = new GetDateandExchangeRateList
            (
                    new GetExchangeRateStart
                    {
                        BuyingExchangeDate = exchangeFormDate.dateStart,
                        BuyingExchangeRate = GetDateExchange.GetExchangeRate(exchangeFormDate.dateStart)
                    },
                 new GetExchangeRateFinish
                 {
                     BuyingExchangeDate = exchangeFormDate.dateFinish,
                     BuyingExchangeRate = GetDateExchange.GetExchangeRate(exchangeFormDate.dateFinish)
                 }
            );

            return View("Index", exchangeRate);
        }
        /*public IActionResult GetExchange(ExchangeFormDate exchangeFormDate)
        {
            var exchangeRate = new GetDateandExchangeRateList
            (
                    new GetExchangeRateStart
                    {
                BuyingExchangeDate = exchangeFormDate.dateStart,
                BuyingExchangeRate = GetDateExchange.GetExchangeRate(exchangeFormDate.dateStart)
                },
                 new GetExchangeRateFinish
                 {
                BuyingExchangeDate = exchangeFormDate.dateFinish,
                BuyingExchangeRate = GetDateExchange.GetExchangeRate(exchangeFormDate.dateFinish)
                }
            );

            return View("Index", exchangeRate);
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
