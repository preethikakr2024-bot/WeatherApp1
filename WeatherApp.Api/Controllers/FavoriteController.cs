using WeatherApp.Api.Models;
using WeatherApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly MongoService _mongo;

        public FavoriteController(MongoService mongo)
        {
            _mongo = mongo;
        }

        private void AddCorsHeaders()
        {
            Response.Headers["Access-Control-Allow-Origin"] = "*";
            Response.Headers["Access-Control-Allow-Headers"] = "*";
            Response.Headers["Access-Control-Allow-Methods"] = "*";
        }

        [HttpOptions]
        [HttpOptions("{userId}")]
        public IActionResult Preflight()
        {
            AddCorsHeaders();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserFavorite fav)
        {
            AddCorsHeaders();
            if (fav == null) return BadRequest("Favorite cannot be null");
            await _mongo.SaveFavorite(fav);
            return Ok(new { message = "Saved successfully" });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            AddCorsHeaders();
            if (string.IsNullOrWhiteSpace(userId)) return BadRequest("UserId is required");
            var data = await _mongo.GetFavorite(userId);
            return Ok(data);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            AddCorsHeaders();
            if (string.IsNullOrWhiteSpace(userId)) return BadRequest("UserId is required");
            await _mongo.DeleteFavorite(userId);
            return Ok(new { message = "Deleted successfully" });
        }
    }
}