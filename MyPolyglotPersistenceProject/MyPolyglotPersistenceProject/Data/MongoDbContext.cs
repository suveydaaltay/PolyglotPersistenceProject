using MongoDB.Driver;
using MyPolyglotPersistenceProject.Models;

namespace MyPolyglotPersistenceProject.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("YourMongoDb");
        }

        public IMongoCollection<YourEntityMongo> YourEntities => _database.GetCollection<YourEntityMongo>("YourEntities");
    }
}
