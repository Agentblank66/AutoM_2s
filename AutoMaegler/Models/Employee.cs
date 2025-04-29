namespace AutoMaegler.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public Employee(int id, string name, string type, int phoneNumber, string email)
        {
            Id = id;
            Name = name;
            Type = type;
            PhoneNumber = phoneNumber;
            Email = email;
        }


        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Type: {Type} PhoneNumber: {PhoneNumber} Email: {Email}";
        }
    }
}
