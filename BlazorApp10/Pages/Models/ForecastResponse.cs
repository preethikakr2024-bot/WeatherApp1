using System.Collections.Generic;

namespace BlazorApp10.Models
{
    public class ForecastResponse
    {
        public List<ForecastItem> list { get; set; } = new();
    }

    public class ForecastItem
    {
        public Main main { get; set; } = new();
        public List<Weather> weather { get; set; } = new();
        public string dt_txt { get; set; } = "";
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