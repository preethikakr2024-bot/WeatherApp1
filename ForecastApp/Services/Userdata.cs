using System;

namespace UDService.Services;

public class Userdata
{
    public string? Username { get; set; }
    public string? Password { get; set; }

    public async Task updateDetails(string name, string password)
    {
        Username = name;
        Password = password;
        await Task.Delay(100); // Simulate async work
    }
}
