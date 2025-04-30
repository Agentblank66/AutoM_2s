namespace AutoMaegler.Models
{
    public class OrderLeasing : Order
    {
        public int Dipositum { get; set; }
        public DateTime LeasingDate { get; set; }

        public OrderLeasing(int id, Car car, Employee employee, Customer customer, OrderType type, int leasingPrice, DateTime leasingDate)
            : base(id, car, employee, customer, type)
        {
            Dipositum = leasingPrice;
            LeasingDate = leasingDate;
        }
    }
}
