namespace AutoMaegler.Models
{
    public abstract class Order
    {
        public int Id { get; set; }
        Car Car { get; set; }
        Employee Employee { get; set; }
        Customer Customer { get; set; }
    }
}
