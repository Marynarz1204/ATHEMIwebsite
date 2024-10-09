using ATHEMIwebsite.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
namespace ATHEMIwebsite.Services;
public class MongoDBService
{

    private readonly IMongoCollection<Dog> _dogCollection;
    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _dogCollection = database.GetCollection<Dog>(mongoDBSettings.Value.CollectionNameDogs);
    }
    public async Task<List<Dog>> GetDogsAsync()
    {
        return await _dogCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task CreateDogAsync(Dog dog)
    {
        await _dogCollection.InsertOneAsync(dog);
        return;
    }
    public async Task AddToDogAsync(string id, string movieId)
    {
        FilterDefinition<Dog> filter = Builders<Dog>.Filter.Eq("Id", id);
        UpdateDefinition<Dog> update = Builders<Dog>.Update.AddToSet<string>("movieIds", movieId);
        await _dogCollection.UpdateOneAsync(filter, update);
        return;
    }
    public async Task DeleteDogAsync(string id)
    {
        FilterDefinition<Dog> filter = Builders<Dog>.Filter.Eq("Id", id);
        await _dogCollection.DeleteOneAsync(filter);
        return;
    }
}