using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMaegler.EFDbContext
{
    public class UserDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connStr = "Server=mysql62.unoeuro.com;Port=3306;Database=okronborg_dk_db;User ID=okronborg_dk;Password=gnb6xtyDdc3eafE9zkrh;";
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
