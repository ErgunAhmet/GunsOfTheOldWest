using AhmetErgun_GunsOfTheOldWest.Models;
using AhmetErgun_GunsOfTheOldWest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AhmetErgun_GunsOfTheOldWest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Game _game;
        public HomeController(ILogger<HomeController> logger, Game game)
        {
            _logger = logger;
            _game = game;
        }

        public IActionResult Index()
        {

            int numberOfBullets = _game.getBullets();
            
            return View(numberOfBullets);
        }

        public IActionResult Shoot()
        {
            string result = _game.shoot();

            switch (result)
            {
                case "won":
                    return RedirectToAction("Won");
                case "continue":
                    return RedirectToAction("Index");
                case "lost":
                    return RedirectToAction("Lost");
                default:
                    return RedirectToAction("Index");
            }

        }

        public IActionResult Won()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Won(Shooter shooter)
        {
            if (ModelState.IsValid)
            {
                Shooter shooterCreated = _game.AddShooter(shooter);
                return RedirectToAction("Summary", shooterCreated);
            }
            return View("Won");
            
        }

        public IActionResult Summary(Shooter shooter)
        {
            return View("Summary", shooter);
        }
        [HttpGet]
        public IActionResult Lost()
        {
            return View("Buy");
        }

        [HttpPost]
        public IActionResult Bought()
        {
            int bullets = 0;
            if (int.TryParse(Request.Form["bullets2"], out int bullets2))
            {
                bullets = bullets2;
            }
            else if (int.TryParse(Request.Form["bullets7"], out int bullets7))
            {
                bullets = bullets7;
            }
            else if (int.TryParse(Request.Form["bullets12"], out int bullets12))
            {
                bullets = bullets12;
            }

            _game.AddBullets(bullets);
            return RedirectToAction("Index");
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