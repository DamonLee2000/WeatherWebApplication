namespace WeatherWebApp.Models
{
    public class WeatherApiResponse
    {
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Main // we make this class because the JSON object is in a list and the temperature lies within the "Main" field.
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double humidity { get; set; }
    }

    
    public class Weather
    {
        public string main { get; set; } // main description of the weather
        public string desciption { get; set; } // additional description of the weather
        public string icon { get; set; } // gives a code, which is a file name for a png.
    }
}
