using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AutoMaegler.Pages.LogIn
{
    public class LogInPageModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public static Customer LoggedInCustomer { get; set; } = null;
        public static Employee LoggedInEmployee { get; set; } = null;

        private UserService _userService;

        public LogInPageModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            List<Customer> customers = _userService.Customers;
            foreach (Customer customer in customers)
            {

                if (UserName == customer.Email && Password == customer.Password)
                {

                    LoggedInCustomer = customer;

                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName) };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Index");

                }

            }
            List<Employee> employees = _userService.Employees;
            foreach (Employee employee in employees)
            {

                if (UserName == employee.Email && Password == employee.Password)
                {

                    LoggedInEmployee = employee;

                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName) };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Index");

                }

            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
