using AutoMaegler.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages.Admin
{
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
