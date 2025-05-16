using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public interface IOrderService
    {
        /// <summary>
        /// Methods that any class implementing this interface must implement.
        /// </summary>
        List<Order> GetOrders();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        Order GetOrder(int id, Order.OrderType type);
        Order DeleteOrder(int id, Order.OrderType type);
        IEnumerable<Order> NameSearch(string str);
        IEnumerable<Order> PriceFilter(double minPrice, double maxPrice, double minLeasing, double maxLeasing);
        IEnumerable<T> SortById<T>(IEnumerable<T> orders) where T : Order;
        IEnumerable<T> SortByIdDecending<T>(IEnumerable<T> orders) where T : Order;
        IEnumerable<T> SortByName<T>(IEnumerable<T> orders) where T : Order;
        IEnumerable<T> SortByNameDecending<T>(IEnumerable<T> orders) where T : Order;
        IEnumerable<T> SortByPrice<T>(IEnumerable<T> orders) where T : Order;
        IEnumerable<T> SortByPriceDescending<T>(IEnumerable<T> orders) where T : Order;

    }
}
