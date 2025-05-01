namespace AutoMaegler.Models
{
    public class Employee: User
    {
      
        public string Type { get; set; }

        public Employee(int id, string name, string type, int phoneNumber, string email, string password): base(id, name, email, password)
        {
            Type = type;
        }


        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Type: {Type} Email: {Email}";
        }
    }
}
