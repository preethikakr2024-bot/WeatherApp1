namespace WeatherApp.Models
{
    public class WeatherResponse
    {
        public string name { get; set; } = "";
        public Main main { get; set; } = new Main();
        public Weather[] weather { get; set; } = new Weather[0];
    }

    public class Main
    {
        public float temp { get; set; }
    }

    public class Weather
    {
        public string description { get; set; } = "";
    }
}