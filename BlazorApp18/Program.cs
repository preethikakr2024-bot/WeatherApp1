using BlazorApp18.Components;
using BlazorApp18.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ AUTH DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AuthConnection")));

// ✅ USER DATA DB
builder.Services.AddDbContext<UserDataDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("UserDataConnection")));

var app = builder.Build();

// ✅ Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage(); // 🔥 shows real error instead of 500
}

app.UseStaticFiles();
app.UseRouting();

// ✅ Map components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();