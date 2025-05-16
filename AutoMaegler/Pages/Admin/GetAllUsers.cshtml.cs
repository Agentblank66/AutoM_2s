using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Admin
{
    [Authorize(Roles = "Employee")]
    public class GetAllUsersModel : PageModel
    {
       
        public UserService UserService { get; set; }
        


        public GetAllUsersModel(UserService userService)
        {
            UserService = userService;
        }

        public void OnGet()
        {
               
        }
        

    }
}
