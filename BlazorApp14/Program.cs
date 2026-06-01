using BlazorApp14.Services;
using BlazorApp14;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 🌐 HttpClient setup
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

// 🎨 MudBlazor services
builder.Services.AddMudServices();

// 🔐 User Management Service (IMPORTANT for your login/signup)
builder.Services.AddSingleton<AuthService>();

await builder.Build().RunAsync();