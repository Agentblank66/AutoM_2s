using AutoMaegler.Pages.LogIn;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMaegler.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //if (LogInPageModel.LoggedInCustomer == null)
            //{
            //    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //}
            //else if(LogInPageModel.LoggedInEmployee == null)
            //{
            //    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //}
        }
    }
}
