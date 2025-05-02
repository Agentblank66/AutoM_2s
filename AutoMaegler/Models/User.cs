using System.ComponentModel.DataAnnotations;

namespace AutoMaegler.Models
{
    public class User
    {
        /// <summary>
        /// A property which contains the id of the user.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// A property which contains the name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A property which contains the email of the user, 
        /// where the lenght cant be more than 50 characters.
        /// </summary>
        [StringLength(50, ErrorMessage = "Email length can't be more than 50 characters.")]
        public string Email { get; set; }
        /// <summary>
        /// A property which contains the password of the user, which is required.
        /// </summary>
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
