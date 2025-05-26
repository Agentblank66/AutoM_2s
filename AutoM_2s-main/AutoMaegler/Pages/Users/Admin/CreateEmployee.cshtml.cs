using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Users.Admin
{
    [Authorize(Roles = "Employee")]
    public class CreateEmployeeModel : PageModel
    {
        private UserService _userService;
        private readonly PasswordHasher<string> _hasher;

        [BindProperty]
        public Models.Employee Employee { get; set; }

        public CreateEmployeeModel(UserService userService)
        {
            _userService = userService;
            _hasher = new PasswordHasher<string>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Employee.Password = _hasher.HashPassword(Employee.Email, Employee.Password);
            _userService.AddUser(Employee);
            return RedirectToPage("/Users/Admin/GetAllUsers");
        }
    }
}
