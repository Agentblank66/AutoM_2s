using Microsoft.EntityFrameworkCore;

namespace AutoMaegler.EFDbContext
{
    public class OrderDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connStr = "Server=mysql62.unoeuro.com;Port=3306;Database=okronborg_dk_db;User ID=okronborg_dk;Password=gnb6xtyDdc3eafE9zkrh; Initial Catalog=OKronborg_dk_db; Integrated Security=True; Connect Timeout=30; Encrypt=False";
        }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderBuy> BuyOrders { get; set; }
        public DbSet<Models.OrderLeasing> LeaseOrders { get; set; }
        public DbSet<Models.OrderSale> SaleOrders { get; set; }
    }
}
