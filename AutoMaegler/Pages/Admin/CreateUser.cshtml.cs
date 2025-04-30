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
        private UserService _userService;

        [BindProperty]
        public string Email { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool WishToSell { get; set; }


        public CreateUserModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }
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
