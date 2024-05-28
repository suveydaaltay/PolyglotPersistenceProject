using Microsoft.AspNetCore.Mvc;
using MyPolyglotPersistenceProject.Data;
using MyPolyglotPersistenceProject.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace MyPolyglotPersistenceProject.Controllers
{
   
    public class YourEntityController : Controller
    {
        private const string V = "redis/{id}";
        private readonly DataConnector _dataConnector;

        public YourEntityController(DataConnector dataConnector)
        {
            _dataConnector = dataConnector;
        }

       
        public async Task<IActionResult> CreateInSqlServer(YourEntity entity)
        {
            _dataConnector.SqlServerContext.YourEntities.Add(entity);
            await _dataConnector.SqlServerContext.SaveChangesAsync();
            return Ok(entity);
        }

        public IActionResult CreateInMongoDb(YourEntityMongo entity)
        {
            entity.Id = Guid.NewGuid().ToString(); 
            _dataConnector.MongoContext.YourEntities.InsertOne(entity);
            return Ok(entity);
        }

        public IActionResult CreateInRedis(YourEntity entity)
        {
            _dataConnector.RedisContext.SetYourEntity(entity.ToString(), entity);
            return Ok(entity);
        }

        // SQL Server - Read
        [HttpGet("sql")]
        public async Task<IActionResult> GetFromSqlServer()
        {
            var data = await _dataConnector.SqlServerContext.YourEntities.ToListAsync();
            return Ok(data);
        }

        // MongoDB - Read
        [HttpGet("mongo")]
        public IActionResult GetFromMongoDb()
        {
            var data = _dataConnector.MongoContext.YourEntities.Find(_ => true).ToList();
            return Ok(data);
        }

        // Redis - Read
        [HttpGet("redis/{id}")]
        public IActionResult GetFromRedis(string id)
        {
            var entity = _dataConnector.RedisContext.GetYourEntity(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // SQL Server - Update
        [HttpPut("sql/{id}")]
        public async Task<IActionResult> UpdateInSqlServer(int id, YourEntity entity)
        {
            var existingEntity = await _dataConnector.SqlServerContext.YourEntities.FindAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }

            existingEntity.Name = entity.Name;
            await _dataConnector.SqlServerContext.SaveChangesAsync();
            return Ok(existingEntity);
        }

        // MongoDB - Update
        [HttpPut("mongo/{id}")]
        public IActionResult UpdateInMongoDb(string id, YourEntityMongo entity)
        {
            var filter = Builders<YourEntityMongo>.Filter.Eq(e => e.Id, id);
            var update = Builders<YourEntityMongo>.Update.Set(e => e.Name, entity.Name);
            var result = _dataConnector.MongoContext.YourEntities.UpdateOne(filter, update);

            if (result.MatchedCount == 0)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        // Redis - Update
        [HttpPut("redis/{id}")]
        public IActionResult UpdateInRedis(string id, YourEntity entity)
        {
            var existingEntity = _dataConnector.RedisContext.GetYourEntity(id);
            if (existingEntity == null)
            {
                return NotFound();
            }

            _dataConnector.RedisContext.SetYourEntity(id, entity);
            return Ok(entity);
        }

        // SQL Server - Delete
        [HttpDelete("sql/{id}")]
        public async Task<IActionResult> DeleteFromSqlServer(int id)
        {
            var entity = await _dataConnector.SqlServerContext.YourEntities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _dataConnector.SqlServerContext.YourEntities.Remove(entity);
            await _dataConnector.SqlServerContext.SaveChangesAsync();
            return Ok();
        }

        // MongoDB - Delete
        [HttpDelete("mongo/{id}")]
        public IActionResult DeleteFromMongoDb(string id)
        {
            var result = _dataConnector.MongoContext.YourEntities.DeleteOne(e => e.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        // Redis - Delete
        [HttpDelete(V)]
        public IActionResult DeleteFromRedis(string id)
        {
            var existingEntity = _dataConnector.RedisContext.GetYourEntity(id);
            if (existingEntity == null)
            {
                return NotFound();
            }

            _dataConnector.RedisContext.DeleteYourEntity(id);
            return Ok();
        }
    }
}
