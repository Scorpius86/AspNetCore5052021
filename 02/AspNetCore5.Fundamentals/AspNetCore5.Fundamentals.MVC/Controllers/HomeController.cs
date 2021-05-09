using AspNetCore5.Fundamentals.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5.Fundamentals.MVC.Controllers
{
    [Route("hogar/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel
            {
                Title = "Home - Index",
                Author = "Erick Aróstegui",
                People = new List<PersonViewModel>
                {
                    new PersonViewModel("Person 01","Last Name 01",28),
                    new PersonViewModel("Person 02","Last Name 02",29),
                },
                Districts = new List<string> { "Miraflores", "San Juan e Lurigancho"}
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int age)
        {
            Console.WriteLine(age);
            return RedirectToAction("Index");
        }
        
        [Route("[controller]/javascript")]
        public IActionResult JsonAction(int age)
        {
            PersonViewModel person = new PersonViewModel("Erick", "Aróstegui", 39);
            return Json(person);
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
