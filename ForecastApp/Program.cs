using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ForecastApp;
using URService.Services; // Assuming this is a valid namespace in your project
using UDService.Services;
using SigninService.Models;
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient for API calls
builder.Services.AddScoped(sp => new HttpClient 
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Add MudBlazor UI services
builder.Services.AddMudServices();

// Register your custom service (singleton)
builder.Services.AddScoped<UnregisterService>();
builder.Services.AddScoped<Userdata>();

await builder.Build().RunAsync();
