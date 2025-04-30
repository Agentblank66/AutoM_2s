using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public interface IOrderService
    {
        public List<Order> GetOrders();
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public Order GetOrder(int id, Order.OrderType type);
        public Order DeleteOrder(int id);
        public IEnumerable<Order> NameSearch(string str);
        public IEnumerable<Order> PriceFilter(int minPrice, int maxPrice);
    }
}
