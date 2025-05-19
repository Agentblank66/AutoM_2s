using System.ComponentModel.DataAnnotations;

namespace AutoMaegler.Models
{
    public abstract class User
    {
        /// <summary>
        /// Enumeration for User types.
        /// </summary>
        public enum UserType
        {
            Customer,
            Employee
        }
        /// <summary>
        /// Properties of the User class.
        /// </summary>
        public UserType UserTypes { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Key]
        [StringLength(100, ErrorMessage = "Email length can't be more than 100 characters.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// A constructor which initializes the user with the given parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public User(int id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            
        }
    }
}
