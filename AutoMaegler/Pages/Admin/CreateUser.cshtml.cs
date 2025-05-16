using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AutoMaegler.Pages.Admin
{
    
    public class CreateUserModel : PageModel
    {
        /// <summary>
        ///  Properties of the CreateUserModel class.
        /// </summary>
        private UserService _userService;
        [BindProperty]
        public string Email { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public bool WishToSell { get; set; }
        public string Type { get; set; }
        public string UserType { get; set; }
        private PasswordHasher<string> passwordHasher;


        /// <summary>
        /// A constructor which initializes the user service.
        /// </summary>
        /// <param name="userService"></param>
        public CreateUserModel(UserService userService)
        {
            _userService = userService;
            passwordHasher = new PasswordHasher<string>();
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// A method which checks if the binding properties are correct 
        /// else it returns to the page. It then adds the customer to the userservice 
        /// and redirects to the index page.
        /// </summary>
        /// <returns>
        /// Returns the same page with an error message if the model state is invalid.
        /// Returns the index page if the model state is valid.
        /// </returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (UserType == "Customer") 
            {
                _userService.AddUser(new Customer(Id, FirstName, LastName, PhoneNumber, Email, passwordHasher.HashPassword(null, Password), WishToSell));
            }
            else if (UserType == "Employee")
            {
                _userService.AddUser(new Employee(Id, FirstName, LastName, Type, Email, passwordHasher.HashPassword(null, Password)));
            }
            return RedirectToPage("/Index");
        }
    }
}
