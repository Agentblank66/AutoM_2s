using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static AutoMaegler.Models.User;

namespace AutoMaegler.Pages
{
    public class EditUserModel : PageModel
    {
        private UserService _userService;
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Type { get; set; } // kun for Employee
        [BindProperty]
        public int PhoneNumber { get; set; } // kun for Customer
        [BindProperty]
        public bool WishToSell { get; set; } // kun for Customer
        [BindProperty]
        public UserType? UserType { get; set; }
        public string Role { get; set; } 

        public EditUserModel(UserService userService)
        {
            _userService = userService;
        }


        public IActionResult OnGet(int id, UserType userType)
        {
            var user = _userService.GetUser(id, userType);
            if (user == null)
                return RedirectToPage("/NotFound");

            UserType = user.UserTypes;
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            if (user is Customer customer)
            {
                PhoneNumber = customer.PhoneNumber;
                WishToSell = customer.WishToSell;
            }
            else if (user is Employee employee)
            {
                Type = employee.Type;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (UserType == Models.User.UserType.Customer)
            {
                ModelState.Remove(nameof(Type));
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            User updatedUser = null;
            if (UserType == Models.User.UserType.Customer)
            {
                updatedUser = new Customer(Id, FirstName, LastName, PhoneNumber, Email, Password, WishToSell);
                updatedUser.UserTypes = (UserType)UserType;
                
            }
            else if (UserType == Models.User.UserType.Employee)
            {
                updatedUser = new Employee(Id, FirstName, LastName, Type, Email, Password);
                updatedUser.UserTypes = (UserType)UserType;

                
            }
            _userService.UpdateUser(updatedUser);
            return RedirectToPage("/Admin/GetAllUsers");
        }
    }
}
