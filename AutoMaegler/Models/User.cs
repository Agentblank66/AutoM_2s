using System.ComponentModel.DataAnnotations;

namespace AutoMaegler.Models
{
    public class User
    {
        /// <summary>
        /// Properties of the User class.
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Email length can't be more than 50 characters.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// A constructor which initializes the user with the given parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// A method which overrides the ToString method to return the user properties.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Email: {Email} Password {Password}";
        }

    }
}
