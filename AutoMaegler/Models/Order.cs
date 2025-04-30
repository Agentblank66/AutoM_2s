namespace AutoMaegler.Models
{
    public abstract class Order
    {
        public enum leasingType
        {
            Leasing,
            Buy,
            Sale
        }

        public leasingType Type { get; set; }
        public int Id { get; set; }
        Car Car { get; set; }
        Employee Employee { get; set; }
        Customer Customer { get; set; }

        public Order(int id, Car car, Employee employee, Customer customer, leasingType type)
        {
            Id = id;
            Car = car;
            Employee = employee;
            Customer = customer;
            Type = type;
        }
    }
}
