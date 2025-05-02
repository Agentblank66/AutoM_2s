namespace AutoMaegler.Models
{
    public abstract class Order
    {
        /// <summary>
        /// Represents the type of order.
        /// </summary>
        public enum OrderType
        {
            Leasing,
            Buy,
            Sale
        }

        /// <summary>
        /// Properties of the Order class.
        /// </summary>
        public OrderType Type { get; set; }
        public int Id { get; set; }
        public Car Car { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }

        /// <summary>
        /// Constructor for the Order class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="employee"></param>
        /// <param name="customer"></param>
        /// <param name="type"></param>
        public Order(int id, Car car, Employee employee, Customer customer, OrderType type)
        {
            Id = id;
            Car = car;
            Employee = employee;
            Customer = customer;
            Type = type;
        }
    }
}
