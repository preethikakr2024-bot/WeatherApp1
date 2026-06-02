using MongoDB.Driver;
using WeatherApp.Api.Models;

namespace WeatherApp.Api.Services
{
    public class MongoService
    {
        private readonly IMongoCollection<UserFavorite> _favorites;

        public MongoService(IMongoClient client)
        {
            var database = client.GetDatabase("WeatherApp");
            _favorites = database.GetCollection<UserFavorite>("Favorites");
        }

        public async Task SaveFavorite(UserFavorite fav)
        {
            var existing = await _favorites
                .Find(f => f.UserId == fav.UserId)
                .FirstOrDefaultAsync();

            if (existing == null)
                await _favorites.InsertOneAsync(fav);
            else
                await _favorites.ReplaceOneAsync(f => f.UserId == fav.UserId, fav);
        }

        public async Task<UserFavorite?> GetFavorite(string userId)
        {
            return await _favorites
                .Find(f => f.UserId == userId)
                .FirstOrDefaultAsync();
        }

        // ✅ Added Delete
        public async Task DeleteFavorite(string userId)
        {
            await _favorites.DeleteOneAsync(f => f.UserId == userId);
        }
    }
}