using AutoMaegler.Models;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace AutoMaegler.Pages.LogIn
{
    public class LogInPageModel : PageModel
    {
        /// <summary>
        /// Properties of the LogInPageModel class.
        /// </summary>
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public static Customer LoggedInCustomer { get; set; } = null;
        public static Employee LoggedInEmployee { get; set; } = null;
        private UserService _userService;
        public Models.User.UserType UserType { get; set; }

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

                    var passwordHasher = new PasswordHasher<string>();

                    if (passwordHasher.VerifyHashedPassword(null, customer.Password, Password) == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Email, UserName),
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    }
                }

            }
            List<Employee> employees = _userService.Employees;
            foreach (Employee employee in employees)
            {

                if (UserName == employee.Email)
                {
                   
                    LoggedInEmployee = employee;

                    var passwordHasher = new PasswordHasher<string>();

                    if (passwordHasher.VerifyHashedPassword(null, employee.Password, Password) == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, UserName),
                        new Claim(ClaimTypes.Role, "Employee")
                        };

                        //if (UserName == "Employee") claims.Add(new Claim(ClaimTypes.Role, "Employee"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    }
                }

            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
