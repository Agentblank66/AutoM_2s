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
        Car Car { get; set; }
        Employee Employee { get; set; }
        Customer Customer { get; set; }

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
