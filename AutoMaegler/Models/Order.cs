namespace AutoMaegler.Models
{
    public abstract class Order
    {
        public enum OrderType
        {
            Leasing,
            Buy,
            Sale
        }

        public OrderType Type { get; set; }
        public int Id { get; set; }
        public Car Car { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }

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
