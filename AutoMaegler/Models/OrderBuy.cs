namespace AutoMaegler.Models
{
    public class OrderBuy : Order
    {
        /// <summary>
        /// Properties of the OrderBuy class.
        /// </summary>
        public int BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }

        /// <summary>
        /// Constructor for the OrderBuy class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="employee"></param>
        /// <param name="customer"></param>
        /// <param name="type"></param>
        /// <param name="buyPrice"></param>
        /// <param name="buyDate"></param>
        public OrderBuy(int id, Car car, Employee employee, Customer customer, OrderType type,int buyPrice, DateTime buyDate)
        : base(id, car, employee, customer, type)
        {
            BuyPrice = buyPrice;
            BuyDate = buyDate;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the OrderBuy object.
        /// </summary>
        /// <returns> A string with properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Employee: {Employee} Customer: {Customer} Type: {Type} BuyPrice: {BuyPrice} BuyDate: {BuyDate}";
        }
    }

}
