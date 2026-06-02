using WeatherApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<WeatherApp.Components.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ✅ HttpClient pointing to your live Render API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://weatherapp3-d1rx.onrender.com/")
});

// ✅ Services
builder.Services.AddScoped<SupabaseService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<FavoriteApiService>();

// ✅ MudBlazor
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass =
        MudBlazor.Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
});

await builder.Build().RunAsync();