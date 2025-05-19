using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Admin
{
    /// <summary>
    /// This class is used to get all users from the database, where only Employees can go to the page.
    /// </summary>
    [Authorize(Roles = "Employee")]
    public class GetAllUsersModel : PageModel
    {
        /// <summary>
        /// Property of the GetAllUsersModel class.
        /// </summary>
        public UserService UserService { get; set; }


        /// <summary>
        /// Constructor of the GetAllUsersModel class.
        /// </summary>
        /// <param name="userService"></param>
        public GetAllUsersModel(UserService userService)
        {
            UserService = userService;
        }

        public void OnGet()
        {
               
        }
        

    }
}
