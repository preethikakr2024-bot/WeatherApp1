using System;
using System.Text;
using System.Text.Json;
using MyWeatherApp.Pages;
using Supabase;
using signup.Models;

namespace LoginService.Services;

public class SignInService
{
    private const string ApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImJ1dmloZnJjYmFicGd0eHllcGZ5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDczMTMyODAsImV4cCI6MjA2Mjg4OTI4MH0.Xnqqwg08fGbznn-Wk4kfRwU07CdVV6IecH86rpsaLl4";
    private const string BaseUrl = "https://buvihfrcbabpgtxyepfy.supabase.co";
    private readonly HttpClient httpc1;
    public SignInService()
    {
        httpc1 = new HttpClient { BaseAddress = new Uri(BaseUrl) };
    }

    public async Task<bool> CheckDataAsync(RegisterModel models)
    {
        try
        {
            string endpoint = $"/auth/v1/token?grant_type=password&apikey={ApiKey}";
            var SignInData = new
            {
                email = models.Email,
                password = models.Password
            };
            string jsonContent = JsonSerializer.Serialize(SignInData);
            HttpResponseMessage responseMessage = await httpc1.PostAsync(endpoint, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("successful");
                return true;
            }
            else
            {
                Console.WriteLine("failed");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error: {ex}");
            return false;
        }

    }
}
