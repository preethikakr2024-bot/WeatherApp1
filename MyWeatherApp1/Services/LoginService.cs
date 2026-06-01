using System.Text;
using System.Text.Json;
using SignModel.Models; // Your RegisterModel
using SigninService.Models; // AuthResponseModel
using System.Net.Http.Headers;


namespace SigninService.Services;

public class LoginService
{
    private readonly string ApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImJ1dmloZnJjYmFicGd0eHllcGZ5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDczMTMyODAsImV4cCI6MjA2Mjg4OTI4MH0.Xnqqwg08fGbznn-Wk4kfRwU07CdVV6IecH86rpsaLl4";
    private readonly string BaseUrl = "https://buvihfrcbabpgtxyepfy.supabase.co";
    private readonly HttpClient httpc;

    public LoginService()
    {
        httpc = new HttpClient { BaseAddress = new Uri(BaseUrl) };
    }
    private string accessToken = string.Empty;
    private string Pmail = string.Empty;

    public async Task<bool> CheckDataAsync(RegisterModel model)
    {
        try
        {
            string endpoint = "/auth/v1/token?grant_type=password";
            Pmail = model.Email;
            Console.WriteLine(Pmail);
            var signInData = new
            {
                email = model.Email,
                password = model.Password
            };

            string jsonContent = JsonSerializer.Serialize(signInData);
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Headers.Add("apikey", ApiKey);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await httpc.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var authResponse = JsonSerializer.Deserialize<AuthResponseModel>(responseBody, options);

                if (authResponse?.access_token != null)
                {
                    accessToken = authResponse.access_token;
                    string uid = authResponse.user?.id;

                    // Console.WriteLine("✅ Access Token: " + accessToken);
                    // Console.WriteLine("✅ UID: " + uid);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return false;
        }
    }
    public class FavouriteResult
    {
        public string[] favourite { get; set; }
    }
    public class FavouriteResult1
    {
        public string name { get; set; }
    }


    public async Task<List<string>> GetFavouritesAsync()
    {
        string table = "profile";
        string filter = $"email=eq.{Pmail}";

        var request = new HttpRequestMessage(HttpMethod.Get, $"/rest/v1/{table}?{filter}");
        request.Headers.Add("apikey", ApiKey);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await httpc.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var favourites = JsonSerializer.Deserialize<List<FavouriteResult>>(result, options);
            // Console.WriteLine(favourites);
            return favourites?.FirstOrDefault()?.favourite?.ToList() ?? new List<string>();
        }
        else
        {
            Console.WriteLine("Failed to fetch favourites.");
            return new List<string>();
        }
    }

    public async Task<bool> UpdateProfileAsync(List<string> fav1)
    {
        string table = "profile"; // or your table name
        string filter = $"email=eq.{Pmail}";
        string[] fav = fav1.ToArray();
        var updateData = new
        {
            favourite = fav,
        };

        var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"/rest/v1/{table}?{filter}");
        request.Headers.Add("apikey", ApiKey);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        request.Headers.Add("Prefer", "return=representation");

        string json = JsonSerializer.Serialize(updateData);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpc.SendAsync(request);
        string body = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Update successful:");
            Console.WriteLine(body);
            return true;
        }
        else
        {
            Console.WriteLine("Failed to update:");
            Console.WriteLine(body);
            return false;
        }
    }
    public async Task<string> GetUserName()
    {
        string table = "profile";
        string filter = $"email=eq.{Pmail}";

        var request = new HttpRequestMessage(HttpMethod.Get, $"/rest/v1/{table}?{filter}");
        request.Headers.Add("apikey", ApiKey);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await httpc.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var nameData = JsonSerializer.Deserialize<List<FavouriteResult1>>(result, options);
            Console.WriteLine("name fetched");
            return nameData?.FirstOrDefault()?.name ?? "No name found";
        }
        else
        {
            Console.WriteLine("Failed to fetch user.");
            return "no user";
        }
    }

}
