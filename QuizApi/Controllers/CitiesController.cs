using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
         private readonly MongoDbContext _context;

    public CitiesController(MongoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
        var cities = await _context.Cities.Find(_ => true).ToListAsync();
        return Ok(cities);
    }
    }
}
