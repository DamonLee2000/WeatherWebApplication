namespace WeatherWebApp.Models
{
    // fields should be identical to the json object.
    // ex: can't have this "lat" be "latitude" because OpenWeatherMap API's JSON object is "lat"
    public class GeoLocationApiResponse
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string name { get; set; } // city name
    }
}
