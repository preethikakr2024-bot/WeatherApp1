using System;
using System.Text;
using System.Text.Json;
using signup.Models;
using Supabase;
namespace SignUpService.Services;

public class RegisterService
{
    private const string ApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImJ1dmloZnJjYmFicGd0eHllcGZ5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDczMTMyODAsImV4cCI6MjA2Mjg4OTI4MH0.Xnqqwg08fGbznn-Wk4kfRwU07CdVV6IecH86rpsaLl4";
    private const string BaseUrl = "https://buvihfrcbabpgtxyepfy.supabase.co";
    private readonly HttpClient httpc1;
    public RegisterService()
    {
        httpc1= new HttpClient{BaseAddress = new Uri(BaseUrl) };
    }
    public async Task InsertDataAsync(RegisterModel model)
    {
        try
        {
            string endpoint = $"/auth/v1/signup?apikey={ApiKey}";

            string jsonContent = JsonSerializer.Serialize(new
            {
                email = model.Email,
                password = model.Password,
            });

            // HttpClient httpClient = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpc1.PostAsync(endpoint, new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            if (!responseMessage.IsSuccessStatusCode)
            {
                string responseText = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine($"Error response: {responseText}");
            }            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
