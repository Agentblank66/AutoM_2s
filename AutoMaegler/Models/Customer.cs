namespace AutoMaegler.Models
{
    public class Customer: User
    {
        public string Address { get; set; }
        public bool WishToSell { get; set; }
        public int PhoneNumber { get; set; }

        public Customer(int id, string name, int phonenumber, string email, string password, string address, bool wishtosell): base(id, name, email, password)
        {
 
            Address = address;
            WishToSell = wishtosell;
            PhoneNumber = phonenumber;
        }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} PhoneNumber: {PhoneNumber} Email: {Email} Address: {Address} WishToSell: {WishToSell}";
        }
    }
}
