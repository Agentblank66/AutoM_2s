using System.ComponentModel.DataAnnotations;

namespace AutoMaegler.Models
{
    public class OrderSale : Order
    {
        /// <summary>
        /// Properties of the OrderSale class.
        /// </summary>

        [Display(Name = "Salgs Pris")]
        [Required(ErrorMessage = "Der skal være en salgs pris tilknyttet ordren")]
        [Range(typeof(double), "0", "10000000", ErrorMessage = "Salgs pris skal være mellem (1) og (2)")]
        public double SalePrice { get; set; }

        [Display(Name = "Salgs Dato")]
        [Required(ErrorMessage = "Der skal være en salgs dato tilknyttet ordren")]
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Constructor for the OrderSale class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="employee"></param>
        /// <param name="customer"></param>
        /// <param name="type"></param>
        /// <param name="salePrice"></param>
        /// <param name="saleDate"></param>
        public OrderSale(int id, Car car, Employee employee, Customer customer, OrderType type, double salePrice, DateTime saleDate)
            : base(id, car, employee, customer, type)
        {
            SalePrice = salePrice;
            SaleDate = saleDate;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the OrderSale object.
        /// </summary>
        /// <returns> A string with the properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Employee: {Employee} Customer: {Customer} Type: {Type} SalePrice: {SalePrice} SaleDate: {SaleDate}";
        }
    }
}
