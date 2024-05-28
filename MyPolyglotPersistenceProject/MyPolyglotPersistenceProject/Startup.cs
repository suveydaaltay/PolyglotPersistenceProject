using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyPolyglotPersistenceProject.Data;

namespace MyPolyglotPersistenceProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // SQL Server
            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));

            // MongoDB
            services.AddSingleton<MongoDbContext>(sp =>
                new MongoDbContext(Configuration.GetConnectionString("MongoDbConnection")));

            // Redis
            services.AddSingleton<RedisDbContext>(sp =>
                new RedisDbContext(Configuration.GetConnectionString("RedisConnection")));

            services.AddTransient<DataConnector>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
