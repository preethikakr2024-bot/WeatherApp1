using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SignModel.Models;
using SigninService.Models;

namespace CreateService.Services
{
    public class SignUpService
    {
        private readonly string ApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImJ1dmloZnJjYmFicGd0eHllcGZ5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDczMTMyODAsImV4cCI6MjA2Mjg4OTI4MH0.Xnqqwg08fGbznn-Wk4kfRwU07CdVV6IecH86rpsaLl4";
        private readonly string BaseUrl = "https://buvihfrcbabpgtxyepfy.supabase.co";
        private readonly HttpClient httpc2;

        public SignUpService()
        {
            httpc2 = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        }

        public async Task<bool> CreateDataAsync(RegisterModel model, string name)
        {
            try
            {
                string endpoint = "/auth/v1/signup";

                var signUpData = new
                {
                    email = model.Email,
                    password = model.Password
                };
                string gmail = model.Email;
                string jsonContent = JsonSerializer.Serialize(signUpData);

                var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
                request.Headers.Add("apikey", ApiKey);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpc2.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var authResponse = JsonSerializer.Deserialize<AuthResponseModel>(responseBody, options);
                    string accessToken = authResponse?.user?.email;

                    // if (!string.IsNullOrEmpty(accessToken))
                    // {
                    //     Console.WriteLine("✅ Access token retrieved: " + accessToken);
                    // }
                    // else
                    // {
                    //     Console.WriteLine($"acesss:{accessToken}");
                    // }

                    if (authResponse?.user?.id != null)
                    {
                        try
                        {
                            string puid = authResponse.user.id;
                            //string email = gmail;
                            string pname = name;
                            // Console.WriteLine("UID: " + puid);

                            // INSERT into Supabase "Users" table
                            var userInsert = new
                            {
                                uid = puid,
                                name = pname,
                                email = gmail,
                                favourite = (string[])null // Optional for now
                            };

                            string insertJson = JsonSerializer.Serialize(userInsert);

                            var insertRequest = new HttpRequestMessage(HttpMethod.Post, "/rest/v1/profile");
                            insertRequest.Headers.Add("apikey", ApiKey);
                            insertRequest.Headers.Add("Authorization", $"Bearer {ApiKey}");
                            //insertRequest.Headers.Add("Prefer", "return=representation");
                            insertRequest.Content = new StringContent(insertJson, Encoding.UTF8, "application/json");

                            var insertResponse = await httpc2.SendAsync(insertRequest);
                            var insertResponseBody = await insertResponse.Content.ReadAsStringAsync();

                            if (insertResponse.IsSuccessStatusCode)
                            {
                                Console.WriteLine("✅ User inserted into database.");
                            }
                            else
                            {
                                Console.WriteLine("⚠️ Failed to insert user: " + insertResponseBody);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        if (authResponse?.access_token != null)
                        {
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Failed to retrieve UID (authResponse/user was null).");
                    }

                    return true;
                }
                else
                {
                    Console.WriteLine("❌ Signup failed: " + responseBody);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Exception: " + ex.Message);
                return false;
            }
        }

    }
}
