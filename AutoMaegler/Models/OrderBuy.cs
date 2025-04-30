namespace AutoMaegler.Models
{
    public class OrderBuy : Order
    {
        public int BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }

        public OrderBuy(int id, Car car, Employee employee, Customer customer, leasingType type,int buyPrice, DateTime buyDate)
        : base(id, car, employee, customer, type)
        {
            BuyPrice = buyPrice;
            BuyDate = buyDate;
        }
    }

}
