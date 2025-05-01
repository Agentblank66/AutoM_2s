//using AutoMaegler.Models;

//namespace AutoMaegler.Service
//{
//    public class OrderService : IOrderService
//    {
//        private List<Order> _orders;
//        private List<OrderBuy> _orderBuys;
//        private List<OrderLeasing> _orderLeasings;
//        private List<OrderSale> _orderSales;

//        public OrderService()
//        {
//        }

//        public List<Order> GetOrders()
//        {
//            return _orders;

//        }

//        public void AddOrder(Order order)
//        {
//            int orderType = (int)order.Type;
//            switch (orderType)
//            {
//                case 0:
//                    _orderLeasings.Add((OrderLeasing)order);
//                    break;
//                case 1:
//                    _orderBuys.Add((OrderBuy)order);
//                    break;
//                case 2:
//                    _orderSales.Add((OrderSale)order);
//                    break;
//                default:
//                    throw new ArgumentException("Invalid order type");
//            }
//        }

//        public Order GetOrder(int id, Order.OrderType type)
//        {
//            switch (type)
//            {
//                case Order.OrderType.Leasing:
//                    foreach (OrderLeasing order in _orderLeasings)
//                    {
//                        if (order.Id == id)
//                        {
//                            return order;
//                        }
//                    }
//                    break;
//                case Order.OrderType.Buy:
//                    foreach (OrderBuy order in _orderBuys)
//                    {
//                        if (order.Id == id)
//                        {
//                            return order;
//                        }
//                    }
//                    break;
//                case Order.OrderType.Sale:
//                    foreach (OrderSale order in _orderSales)
//                    {
//                        if (order.Id == id)
//                        {
//                            return order;
//                        }
//                    }
//                    break;
//                default:
//                    throw new ArgumentException("Invalid order type");
//            }
//            return null;

//        }

//        public void UpdateOrder(Order order)
//        {
//            Order orderToUpdate = GetOrder(order.Id, order.Type);
//            if (orderToUpdate != null)
//            {
//                orderToUpdate.Car = order.Car;
//                orderToUpdate.Employee = order.Employee;
//                orderToUpdate.Customer = order.Customer;

//                if (order is OrderLeasing)
//                {
//                    OrderLeasing leasingOrder = (OrderLeasing)order;
//                    ((OrderLeasing)orderToUpdate).Dipositum = leasingOrder.Dipositum;
//                    ((OrderLeasing)orderToUpdate).LeasingDate = leasingOrder.LeasingDate;
//                }
//                else if (order is OrderBuy)
//                {
//                    OrderBuy buyOrder = (OrderBuy)order;
//                    ((OrderBuy)orderToUpdate).BuyPrice = buyOrder.BuyPrice;
//                    ((OrderBuy)orderToUpdate).BuyDate = buyOrder.BuyDate;
//                }
//                else if (order is OrderSale)
//                {
//                    OrderSale saleOrder = (OrderSale)order;
//                    ((OrderSale)orderToUpdate).SalePrice = saleOrder.SalePrice;
//                    ((OrderSale)orderToUpdate).SaleDate = saleOrder.SaleDate;
//                }
//            }
//        }
//    }
//}
