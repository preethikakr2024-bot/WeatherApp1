using System;

namespace QuizApi.Models;

public class City
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
