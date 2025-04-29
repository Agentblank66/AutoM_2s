namespace AutoMaegler.Models
{
    public class Order
    {
        public int Id { get; set; }
        Car Car { get; set; }
        Employee Employee { get; set; }
        Customer Customer { get; set; }

        public Order(int id, Car car, Employee employee, Customer customer) 
        {
            Id = id;
            Car = car;
            Employee = employee;
            Customer = customer;
        }

        public Order() 
        { }

        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Employee: {Employee} Customer: {Customer}";
        }
    }
}
