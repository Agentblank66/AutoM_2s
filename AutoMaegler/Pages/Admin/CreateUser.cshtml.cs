using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AutoMaegler.Pages.Admin
{
    
    public class CreateUserModel : PageModel
    {
        /// <summary>
        ///  A private property which holds the userservice..
        /// </summary>
        private UserService _userService;
        /// <summary>
        /// A property which binds the user name.
        /// </summary>
        [BindProperty]
        public string Email { get; set; }
        /// <summary>
        /// A property which binds the password and marks the Password property as Password.
        /// </summary>
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// A property which contains the id of the user.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// A property which contains the name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A property which contains the phonenumber of the user,
        /// </summary>
        public int PhoneNumber { get; set; }
        /// <summary>
        /// A property which contains the address of the user.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// A property which checks if the user wants to sell their car or not.
        /// </summary>
        public bool WishToSell { get; set; }

        /// <summary>
        /// A constructor which initializes the user service.
        /// </summary>
        /// <param name="userService"></param>
        public CreateUserModel(UserService userService)
        {
            _userService = userService;
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
            _userService.AddCustomer(new Customer(Id, Name, PhoneNumber, Email, Password, Address, WishToSell));
            return RedirectToPage("/Index");
        }
    }
}
