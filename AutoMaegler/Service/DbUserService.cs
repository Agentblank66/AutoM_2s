using AutoMaegler.EFDbContext;
using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;
using static AutoMaegler.Models.User;

namespace AutoMaegler.Service
{
    public class DbUserService
    {
        public async Task<List<T>> GetUsers<T>(UserType userType) where T : User
        {
            using (var context = new UserDbContext())
            {
                if (userType == User.UserType.Customer)
                {
                    return await context.Customers.Cast<T>().ToListAsync();
                }
                else if (userType == User.UserType.Employee)
                {
                    return await context.Employees.Cast<T>().ToListAsync();
                }
                else
                {
                    return null;
                }
            }

        }



    }
}
