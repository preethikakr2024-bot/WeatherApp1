using BlazorApp15.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<SupabaseService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddMudServices();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<BlazorApp15.Shared.App>()
    .AddInteractiveServerRenderMode();

app.Run();
