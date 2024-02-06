namespace WeatherWebApp.Models
{
    public class WeatherApiResponse
    {
        public Main main { get; set; }
    }

    public class Main // we make this class because the JSON object is in a list and the temperature lies within the "Main" field.
    {
        public double temp { get; set; }
    }
}
