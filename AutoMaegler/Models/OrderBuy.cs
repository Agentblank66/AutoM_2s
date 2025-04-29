namespace AutoMaegler.Models
{
    public class OrderBuy : Order
    {
        public int BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }

        public OrderBuy(int id, Car car, Employee employee, Customer customer, int buyPrice, DateTime buyDate)
        : base(id, car, employee, customer)
        {
            BuyPrice = buyPrice;
            BuyDate = buyDate;
        }
    }

}
