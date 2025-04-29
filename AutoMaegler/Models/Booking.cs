namespace AutoMaegler.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }


        public Booking(int id, Car car, Customer customer, DateTime date)
        {
            Id = id;
            Car = car;
            Customer = customer;
            Date = date;
        }

        public override string ToString()
        {
            return $"Id: {Id} Car: {Car} Customer: {Customer} Date: {Date}";
        }
    }

}
