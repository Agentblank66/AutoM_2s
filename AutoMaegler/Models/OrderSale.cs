namespace AutoMaegler.Models
{
    public class OrderSale : Order
    {
        public int SalePrice { get; set; }
        public DateTime SaleDate { get; set; }


        public OrderSale(int id, Car car, Employee employee, Customer customer, int salePrice, DateTime saleDate)
            : base(id, car, employee, customer)
        {
            SalePrice = salePrice;
            SaleDate = saleDate;
        }
    }
}
