namespace AutoMaegler.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool WishToSell { get; set; }

        public Customer(int id, string name, int phonenumber, string email, string address, bool wishtosell)
        {
            Id = id;
            Name = name;
            PhoneNumber = phonenumber;
            Email = email;
            Address = address;
            WishToSell = wishtosell;
        }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} PhoneNumber: {PhoneNumber} Email: {Email} Address: {Address} WishToSell: {WishToSell}";
        }
    }
}
