using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMaegler.EFDbContext
{
    public class ImageDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ImageDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Image> Images { get; set; }
    }
}
