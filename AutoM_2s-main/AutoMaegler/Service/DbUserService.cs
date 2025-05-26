using AutoMaegler.EFDbContext;
using AutoMaegler.Models;
using Microsoft.EntityFrameworkCore;
using static AutoMaegler.Models.User;

namespace AutoMaegler.Service
{
    public class DbUserService
    {
        private readonly UserDbContext _context;

        public DbUserService(UserDbContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetCustomers()
        {
                
              return await _context.Customers.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployees()
        {

            return await _context.Employees.ToListAsync();
        }

        public async Task AddUser(User user)
        {
           
                if(user is Customer customer)
                {
                    _context.Customers.Add(customer);
                }
                else if (user is Employee employee)
                {
                    _context.Employees.Add(employee);
                }
                else
                {
                    throw new ArgumentException("Invalid user type");
                }
                _context.SaveChanges();
            
        }

        public async Task SaveUsers(List<User> users)
        {
            
            
                foreach (var user in users)
                {
                    if (user is Customer customer)
                    {
                        _context.Customers.Add(customer);
                    }
                    else if (user is Employee employee)
                    {
                        _context.Employees.Add(employee);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid user type");
                    }
                }
                await _context.SaveChangesAsync();
            
        }

        public async Task DeleteUser(User user)
        {
           
            
                if(user is Customer customer)
                {
                    _context.Customers.Remove(customer);
                }
                else if (user is Employee employee)
                {
                    _context.Employees.Remove(employee);
                }
                else
                {
                    throw new ArgumentException("No users found");
                }
                _context.SaveChanges();
            
        }

        //public async Task UpdateUser(User user)
        //{
           
            
        //        if (user is Customer customer)
        //        {
        //            _context.Customers.Update(customer);
        //        }
        //        else if (user is Employee employee)
        //        {
        //            _context.Employees.Update(employee);
        //        }
        //        else
        //        {
        //            throw new ArgumentException("No users found");
        //        }
        //        _context.SaveChanges();
            
        //}

        public async Task UpdateUser(User user)
        {
            if (user is Customer customer)
            {
                var existing = await _context.Customers.FindAsync(customer.Id);
                if (existing != null)
                {
                    _context.Entry(existing).CurrentValues.SetValues(customer);
                    await _context.SaveChangesAsync();
                }
            }
            else if (user is Employee employee)
            {
                var existing = await _context.Employees.FindAsync(employee.Id);
                if (existing != null)
                {
                    _context.Entry(existing).CurrentValues.SetValues(employee);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new ArgumentException("No users found");
            }
        }

    }
}
