using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace AutoMaegler.Models
{
    public class OrderLeasing : Order
    {
        /// <summary>
        /// Properties of the OrderLeasing class.
        /// </summary>
        [Display(Name = "Depositum")]
        [Required(ErrorMessage = "Der skal være et depositum tilknyttet ordren")]
        [Range(typeof(double), "0", "100000", ErrorMessage = "Depositum skal være mellem (1) og (2)")]
        public double Depositum { get; set; }

        [Display(Name = "Leasing dato")]
        [Required(ErrorMessage = "Der skal være en leasing dato tilknyttet ordren")]
        public DateTime LeasingDate { get; set; }

        [Display(Name = "Månedlig betaling")]
        [Required(ErrorMessage = "Der skal være en månedlig betaling tilknyttet ordren")]
        [Range(typeof(double), "0", "100000", ErrorMessage = "Månedlig betaling skal være mellem (1) og (2)")]
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
            Depositum = dipositum;
            LeasingDate = leasingDate;
            MonthlyPayment = monthlyPayment;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the OrderLeasing object.
        /// </summary>
        /// <returns> A string with properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Employee: {Employee} Customer: {Customer} Type: {Type} Depositum: {Depositum} LeasingDate: {LeasingDate} MonthlyPayment: {MonthlyPayment}";
        }
    }
}
