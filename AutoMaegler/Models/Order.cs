namespace AutoMaegler.Models
{
    public abstract class Order
    {
        public int Id { get; set; }
        Car Car { get; set; }
        Employee Employee { get; set; }
        Customer Customer { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Employee: {Employee} Customer: {Customer}";
        }
    }
}
