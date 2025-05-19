using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMaegler.EFDbContext
{
    public class UserDbContext : DbContext
    {
        /// <summary>
        /// A method which is used to configure the database context.
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connStr = "Server=mysql62.unoeuro.com;Port=3306;Database=okronborg_dk_db;User ID=okronborg_dk;Password=gnb6xtyDdc3eafE9zkrh;";
        }

        /// <summary>
        /// Properties of the UserDbContext class.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
