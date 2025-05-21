using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMaegler.EFDbContext
{
    public class CarDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = "Server=mysql62.unoeuro.com;Port=3306;Database=okronborg_dk_db;User=okronborg_dk;Password=gnb6xtyDdc3eafE9zkrh;";
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Car> Cars { get; set; }
    }
}
