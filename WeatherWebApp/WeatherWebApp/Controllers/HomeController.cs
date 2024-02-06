using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherWebApp.Models;
using System.Text.Json;

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
        public async Task<IActionResult> SubmitForm(UserInputModel userInput) // [frombody] was causing problems
        {
            var zipcode = userInput.Zipcode;
            var country = userInput.Country;

            var apiKey = "237653991af597a3b573e986887b2984";
            var geoApiUrl = $"http://api.openweathermap.org/geo/1.0/zip?zip={zipcode},{country}&appid={apiKey}";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var geoApiResponse = await httpClient.GetStringAsync(geoApiUrl); // geoApiResponse will now be a JSON object

                    if (geoApiResponse != null)
                    {
                        // Parse
                        var geoLocationApiResponseData = JsonSerializer.Deserialize<GeoLocationApiResponse>(geoApiResponse);
                        var latitude = geoLocationApiResponseData.lat.ToString();
                        var longitude = geoLocationApiResponseData.lon.ToString();
                        var city = geoLocationApiResponseData.name;

                        // update SubmitFormViewModel
                        var viewModel = new SubmitFormViewModel
                        {
                            Latitude = latitude,
                            Longtitude = longitude,
                            Zipcode = zipcode,
                            Country = country,
                            City = city
                        };
                        return View(viewModel);
                    }

                }
            }
            catch (HttpRequestException ex) // error http GET
            {
                Console.WriteLine("HTTP GET ERROR: {ex.Message}");
                return BadRequest("Error getting data from OpenWeatherMap API {ex.Message}");
            }
            catch (JsonException ex) // error deserializing API response
            {
                Console.WriteLine("JSON deserialization error: {ex.Message}");
                return BadRequest("Error parsing JSON string {ex.Message}");
            }

            return View("Something Went Wrong");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}