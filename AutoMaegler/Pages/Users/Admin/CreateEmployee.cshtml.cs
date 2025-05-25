using AutoMaegler.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Users.Admin
{
    [Authorize(Roles = "Employee")]
    public class CreateEmployeeModel : PageModel
    {
        private UserService _userService;

        [BindProperty]
        public Models.Employee Employee { get; set; }

        public CreateEmployeeModel(UserService userService)
        {
            _userService = userService;
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
            _userService.AddUser(Employee);
            return RedirectToPage("/Users/Admin/GetAllUsers");
        }
    }
}
