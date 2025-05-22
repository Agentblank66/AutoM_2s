using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;    

namespace AutoMaegler.EFDbContext
{
    public class CarDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Car> Cars { get; set; }
    }
}
