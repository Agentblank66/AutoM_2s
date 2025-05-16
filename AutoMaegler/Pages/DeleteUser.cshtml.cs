using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages
{
    public class DeleteUserModel : PageModel
    {
        private UserService _userService;


        public DeleteUserModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet(int id, Models.User.UserType userType)
        {
           
            var user = _userService.GetUser(id, userType);
            if (user == null)
                return RedirectToPage("/NotFound");


            return Page();
        }

        public IActionResult OnPost(int id, Models.User.UserType userType)
        {
            var user = _userService.GetUser(id, userType);
            if (user == null)
                return RedirectToPage("/NotFound");

            if (user is Customer customer)
                _userService.DeleteUser(customer);
            else if (user is Employee employee)
                _userService.DeleteUser(employee);


            return RedirectToPage("/Admin/GetAllUsers");
        }
    }
}
