using CargoDeliveryService.Models;
using CargoForYou.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CargoDeliveryService.Controllers
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
            return View();
        }

        [HttpPost]
        public IActionResult Result(PacageProportions pacage)
        {
            var depth = pacage.Depth;
            var height = pacage.Height;
            var width = pacage.Width;
            var weigth = pacage.Weight;
            var price = pacage.EstimatedPrice;
            var volume = height * width * depth;

            var cargo4You = new Cargo4You(volume, weigth);
            var shipFaster = new ShipFaster(volume, weigth);
            var maltaShip = new MaltaShip(volume, weigth);
            double cargo4YouPrice = cargo4You.getPrice();
            double shipFasterPrice = shipFaster.getPrice();
            double maltaShipPrice = maltaShip.getPrice();

            double finalPrice = cargo4YouPrice;
            if (finalPrice == 0 || finalPrice > shipFasterPrice)
            {
                finalPrice = shipFasterPrice;
            }
            if (finalPrice == 0 || finalPrice > maltaShipPrice)
            {
                finalPrice = maltaShipPrice;
            }

          

            Console.WriteLine(cargo4YouPrice + ' ' + shipFasterPrice + ' ' + maltaShipPrice + ' ' + finalPrice);

            var model = new TotalPriceModel
            {
                TotalPrice = finalPrice
            };

            return View(model);

        }




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
