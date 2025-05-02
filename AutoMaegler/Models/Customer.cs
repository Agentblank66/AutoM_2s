namespace AutoMaegler.Models
{
    public class Customer: User
    {
        /// <summary>
        /// Properties of the Customer class.
        /// </summary>
        public string Address { get; set; }
        public bool WishToSell { get; set; }
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Constructor which initializes the customer with the given parameters, aswell as the users given parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phonenumber"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="address"></param>
        /// <param name="wishtosell"></param>
        public Customer(int id, string name, int phonenumber, string email, string password, string address, bool wishtosell): base(id, name, email, password)
        {
 
            Address = address;
            WishToSell = wishtosell;
            PhoneNumber = phonenumber;
        }

        /// <summary>
        /// A method which overrides the ToString method to return the customer properties.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} PhoneNumber: {PhoneNumber} Email: {Email} Address: {Address} WishToSell: {WishToSell}";
        }
    }
}
