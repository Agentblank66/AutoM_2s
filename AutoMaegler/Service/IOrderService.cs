using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public interface IOrderService
    {
        /// <summary>
        /// Methods that any class implementing this interface must implement.
        /// </summary>
        public List<Order> GetOrders();
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public Order GetOrder(int id, Order.OrderType type);
        public Order DeleteOrder(int id, Order.OrderType type);
        public IEnumerable<Order> NameSearch(string str);
        public IEnumerable<Order> PriceFilter(double minPrice, double maxPrice, double minLeasing, double maxLeasing);
    }
}
