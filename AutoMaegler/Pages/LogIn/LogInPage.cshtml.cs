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
        /// <summary>
        /// A property which binds the user name.
        /// </summary>
        [BindProperty]
        public string UserName { get; set; }
        /// <summary>
        /// A property which binds the password and marks the Password property as Password.
        /// </summary>
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// A property which holds the message to be displayed on the page.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Properties which holds the logged in customer or employee.
        /// </summary>
        public static Customer LoggedInCustomer { get; set; } = null;
        public static Employee LoggedInEmployee { get; set; } = null;
        /// <summary>
        /// A private property which holds the userservice.
        /// </summary>
        private UserService _userService;

        /// <summary>
        /// A constructor which initializes the user service.
        /// </summary>
        /// <param name="userService"></param>
        public LogInPageModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// A method which checks if the user is a customer or an employee and signs them in.
        /// </summary>
        /// <returns>
        /// Returns the same page with an "Invalid attempt" message if the user is not found, 
        /// otherwise redirects to the index page.
        /// </returns>
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
