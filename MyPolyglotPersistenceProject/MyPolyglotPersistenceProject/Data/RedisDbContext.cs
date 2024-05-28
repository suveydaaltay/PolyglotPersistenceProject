using StackExchange.Redis;
using MyPolyglotPersistenceProject.Models;
using Newtonsoft.Json;

namespace MyPolyglotPersistenceProject.Data
{
    public class RedisDbContext
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisDbContext(string connectionString)
        {
            _redis = ConnectionMultiplexer.Connect(connectionString);
        }

        public IDatabase Database => _redis.GetDatabase();

        public YourEntity GetYourEntity(string key)
        {
            var value = Database.StringGet(key);
            return value.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<YourEntity>(value);
        }

        public void SetYourEntity(string key, YourEntity entity)
        {
            var value = JsonConvert.SerializeObject(entity);
            Database.StringSet(key, value);
        }

        public void DeleteYourEntity(string key)
        {
            Database.KeyDelete(key);
        }
    }
}