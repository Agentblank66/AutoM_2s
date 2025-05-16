using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Private lists for the OrderService class.
        /// </summary>
        private List<Order> _orders;
        private List<OrderBuy> _orderBuys;
        private List<OrderLeasing> _orderLeasings;
        private List<OrderSale> _orderSales;

        /// <summary>
        /// Constructor for the OrderService class.
        /// </summary>
        public OrderService()
        {
        }

        /// <summary>
        /// A method that gets all orders.
        /// </summary>
        /// <returns> All orders </returns>
        public List<Order> GetOrders()
        {
            return _orders;

        }

        /// <summary>
        /// A method that adds an order to the list of orders.
        /// </summary>
        /// <param name="order"></param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// A method that gets an order by id and type.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns> A specific order </returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// A method that updates an order.
        /// </summary>
        /// <param name="order"></param>
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
                    ((OrderLeasing)orderToUpdate).Depositum = leasingOrder.Depositum;
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

        /// <summary>
        /// A method that deletes an order if it exists.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns> Either the deleted order or null </returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// A method that searches for orders by customer name.
        /// </summary>
        /// <param name="str"></param>
        /// <returns> A list of orders </returns>
        public IEnumerable<Order> NameSearch(string str)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in _orders)
            {
                if (order.Customer.FullName.Contains(str, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(order);
                }
            }
            return result;
        }

        /// <summary>
        /// A method that filters orders by price and monthly payment.
        /// </summary>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <param name="minMonthlyPayment"></param>
        /// <param name="maxMonthlyPayment"></param>
        /// <returns> A list of orders </returns>
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

        /// <summary>
        /// A methods that sorts orders by id by using generics to do so.
        /// </summary>
        /// <returns> A list where all the orders are sorted </returns>
        public IEnumerable<T> SortById<T>(IEnumerable<T> orders) where T : Order
        {
            return orders.OrderBy(order => order.Id).ToList();
        }

        /// <summary>
        /// A method that sorts orders by id in descending order by using generics to do so.
        /// </summary>
        /// <returns> A list with the newly sorted orders </returns>
        public IEnumerable<T> SortByIdDecending<T>(IEnumerable<T> orders) where T : Order
        {
            return orders.OrderByDescending(order => order.Id).ToList();
        }

        /// <summary>
        /// A method that sorts orders by customer name by using generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list with the sorted orders by name </returns>
        public IEnumerable<T> SortByName<T>(IEnumerable<T> orders) where T: Order
        {
            return orders.OrderBy(order => order.Customer.FullName).ToList();
        }

        /// <summary>
        /// A method that sorts orders by customer name in descending order by using generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list with the sorted orders by name in descending order </returns>
        public IEnumerable<T> SortByNameDecending<T>(IEnumerable<T> orders) where T : Order
        {
            return orders.OrderByDescending(order => order.Customer.FullName).ToList();
        }

        /// <summary>
        /// A method that sorts orders by price by using generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list where all orders are sorted by price </returns>
        public IEnumerable<T> SortByPrice<T>(IEnumerable<T> orders) where T : Order
        {
            return orders.OrderBy(order => order.Car.Price).ToList();
        }

        /// <summary>
        /// A method that sorts orders by price in descending order by using generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list where all orders are sorted by price in descending order </returns>
        public IEnumerable<T> SortByPriceDescending<T>(IEnumerable<T> orders) where T : Order
        {
            return orders.OrderByDescending(order => order.Car.Price).ToList();
        }
    }
}
