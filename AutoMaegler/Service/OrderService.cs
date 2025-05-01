using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public class OrderService : IOrderService
    {
        private List<Order> _orders;
        private List<OrderBuy> _orderBuys;
        private List<OrderLeasing> _orderLeasings;
        private List<OrderSale> _orderSales;

        public OrderService()
        {
        }

        public List<Order> GetOrders()
        {
            return _orders;

        }

        public void AddOrder(Order order)
        {
            int orderType = (int)order.Type;
            switch (orderType)
            {
                case 0:
                    _orderLeasings.Add((OrderLeasing)order);
                    _orders.Add(order);
                    break;
                case 1:
                    _orderBuys.Add((OrderBuy)order);
                    _orders.Add(order);
                    break;
                case 2:
                    _orderSales.Add((OrderSale)order);
                    _orders.Add(order);
                    break;
                default:
                    throw new ArgumentException("Invalid order type");
            }
        }

        public Order GetOrder(int id, Order.OrderType type)
        {
            switch (type)
            {
                case Order.OrderType.Leasing:
                    foreach (OrderLeasing order in _orderLeasings)
                    {
                        if (order.Id == id)
                        {
                            return order;
                        }
                    }
                    break;
                case Order.OrderType.Buy:
                    foreach (OrderBuy order in _orderBuys)
                    {
                        if (order.Id == id)
                        {
                            return order;
                        }
                    }
                    break;
                case Order.OrderType.Sale:
                    foreach (OrderSale order in _orderSales)
                    {
                        if (order.Id == id)
                        {
                            return order;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid order type");
            }
            return null;

        }

        public void UpdateOrder(Order order)
        {
            Order orderToUpdate = GetOrder(order.Id, order.Type);
            if (orderToUpdate != null)
            {
                orderToUpdate.Car = order.Car;
                orderToUpdate.Employee = order.Employee;
                orderToUpdate.Customer = order.Customer;

                if (order is OrderLeasing)
                {
                    OrderLeasing leasingOrder = (OrderLeasing)order;
                    ((OrderLeasing)orderToUpdate).Dipositum = leasingOrder.Dipositum;
                    ((OrderLeasing)orderToUpdate).LeasingDate = leasingOrder.LeasingDate;
                }
                else if (order is OrderBuy)
                {
                    OrderBuy buyOrder = (OrderBuy)order;
                    ((OrderBuy)orderToUpdate).BuyPrice = buyOrder.BuyPrice;
                    ((OrderBuy)orderToUpdate).BuyDate = buyOrder.BuyDate;
                }
                else if (order is OrderSale)
                {
                    OrderSale saleOrder = (OrderSale)order;
                    ((OrderSale)orderToUpdate).SalePrice = saleOrder.SalePrice;
                    ((OrderSale)orderToUpdate).SaleDate = saleOrder.SaleDate;
                }
            }
        }

        public Order DeleteOrder(int id, Order.OrderType type) 
        {
            Order tempOrderToBeDeleted = GetOrder(id, type);
            if (tempOrderToBeDeleted != null) 
            {
                switch (tempOrderToBeDeleted.Type)
                {
                    case Order.OrderType.Leasing:
                        _orderLeasings.Remove((OrderLeasing)tempOrderToBeDeleted);
                        break;
                    case Order.OrderType.Buy:
                        _orderBuys.Remove((OrderBuy)tempOrderToBeDeleted);
                        break;
                    case Order.OrderType.Sale:
                        _orderSales.Remove((OrderSale)tempOrderToBeDeleted);
                        break;
                    default:
                        throw new ArgumentException("Invalid order type");
                }
                return tempOrderToBeDeleted;
            }
            return null;
        }

        public IEnumerable<Order> NameSearch(string str)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in _orders)
            {
                if (order.Customer.Name.Contains(str, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(order);
                }
            }
            return result;
        }

        public IEnumerable<Order> PriceFilter(double minPrice, double maxPrice, double minMonthlyPayment, double maxMonthlyPayment)
        {
            List<Order> result = new List<Order>();
            foreach (OrderLeasing order in _orderLeasings)
            {
                if (order.MonthlyPayment >= minMonthlyPayment && order.MonthlyPayment <= maxMonthlyPayment)
                {
                    result.Add(order);
                }
            }
            foreach (OrderBuy order in _orderBuys)
            {
                if (order.BuyPrice >= minPrice && order.BuyPrice <= maxPrice)
                {
                    result.Add(order);
                }
            }
            foreach (OrderSale order in _orderSales)
            {
                if (order.SalePrice >= minPrice && order.SalePrice <= maxPrice)
                {
                    result.Add(order);
                }
            }
            return result;
        }
    }
}
