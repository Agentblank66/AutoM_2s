using System.Transactions;

namespace AutoMaegler.Models
{
    public class OrderLeasing : Order
    {
        /// <summary>
        /// Properties of the OrderLeasing class.
        /// </summary>
        public double Dipositum { get; set; }
        public DateTime LeasingDate { get; set; }
        public double MonthlyPayment { get; set; }

        /// <summary>
        /// Constructor for the OrderLeasing class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="employee"></param>
        /// <param name="customer"></param>
        /// <param name="type"></param>
        /// <param name="dipositum"></param>
        /// <param name="leasingDate"></param>
        /// <param name="monthlyPayment"></param>
        public OrderLeasing(int id, Car car, Employee employee, Customer customer, OrderType type, double dipositum, DateTime leasingDate, double monthlyPayment)
            : base(id, car, employee, customer, type)
        {
            Dipositum = dipositum;
            LeasingDate = leasingDate;
            MonthlyPayment = monthlyPayment;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the OrderLeasing object.
        /// </summary>
        /// <returns> A string with properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Employee: {Employee} Customer: {Customer} Type: {Type} Dipositum: {Dipositum} LeasingDate: {LeasingDate} MonthlyPayment: {MonthlyPayment}";
        }
    }
}
