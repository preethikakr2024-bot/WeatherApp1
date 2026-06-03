using WeatherApp.Api.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ MongoDB setup
var mongoConnectionString = builder.Configuration["MongoDbSettings:ConnectionString"];
var mongoDatabaseName = builder.Configuration["MongoDbSettings:DatabaseName"];

builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoConnectionString));
builder.Services.AddSingleton<MongoService>();

// ✅ Secure and Explicit CORS Setup
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://weatherapp-afrontend.onrender.com") // Your exact frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ✅ CORS applied right at the start of the HTTP pipeline
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();