namespace AutoMaegler.Models
{
    public class OrderLeasing : Order
    {
        public int LeasingPrice { get; set; }
        public DateTime LeasingDate { get; set; }

        public OrderLeasing(int id, Car car, Employee employee, Customer customer, int leasingPrice, DateTime leasingDate)
            : base(id, car, employee, customer)
        {
            LeasingPrice = leasingPrice;
            LeasingDate = leasingDate;
        }
    }
}
