


public class WeatherResponse
{
    public string Name { get; set; }
    public MainInfo Main { get; set; }
    public List<WeatherInfo> Weather { get; set; }
}

public class MainInfo
{
    public float Temp { get; set; }

    public int Humidity { get; set; }
}

public class WeatherInfo
{
    public string Main { get; set; }
    public string Description { get; set; }
}