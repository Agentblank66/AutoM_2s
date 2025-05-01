using System.Transactions;

namespace AutoMaegler.Models
{
    public class OrderLeasing : Order
    {
        public double Dipositum { get; set; }
        public DateTime LeasingDate { get; set; }
        public double MonthlyPayment { get; set; }

        public OrderLeasing(int id, Car car, Employee employee, Customer customer, OrderType type, double dipositum, DateTime leasingDate, double monthlyPayment)
            : base(id, car, employee, customer, type)
        {
            Dipositum = dipositum;
            LeasingDate = leasingDate;
            MonthlyPayment = monthlyPayment;
        }
    }
}
