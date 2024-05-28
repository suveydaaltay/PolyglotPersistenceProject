namespace MyPolyglotPersistenceProject.Data
{
    public class DataConnector
    {
        public SqlServerDbContext SqlServerContext { get; }
        public MongoDbContext MongoContext { get; }
        public RedisDbContext RedisContext { get; }

        public DataConnector(SqlServerDbContext sqlServerContext, MongoDbContext mongoContext, RedisDbContext redisContext)
        {
            SqlServerContext = sqlServerContext;
            MongoContext = mongoContext;
            RedisContext = redisContext;
        }
    }
}
 