using Microsoft.EntityFrameworkCore;
using MyPolyglotPersistenceProject.Models;
using System.Collections.Generic;

namespace MyPolyglotPersistenceProject.Data
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }

        public DbSet<YourEntity> YourEntities { get; set; }
    }
}