using System.ComponentModel.DataAnnotations;

namespace AutoMaegler.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Email length can't be more than 50 characters.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Email: {Email}";
        }

    }
}
