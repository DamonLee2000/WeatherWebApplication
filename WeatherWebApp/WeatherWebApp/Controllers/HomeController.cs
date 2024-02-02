using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherWebApp.Models;

namespace WeatherWebApp.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(UserInputModel userInput) // [frombody] was causing problems
        {
            var zipcode = userInput.Zipcode;
            var country = userInput.Country;

            var viewModel = new SubmitFormViewModel
            {
                Zipcode = zipcode,
                Country = country
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}