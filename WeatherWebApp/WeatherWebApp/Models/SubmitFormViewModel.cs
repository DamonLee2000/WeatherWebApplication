namespace WeatherWebApp.Models
{
    public class SubmitFormViewModel
    {
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double TemperatureCelsius { get; set; }
        public double TemperatureFahrenheit { get; set; }
    }
}
