using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuizApi.Models;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection<City> Cities => _database.GetCollection<City>("Cities");
}
