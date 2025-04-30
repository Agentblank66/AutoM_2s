using AutoMaegler.MockData;
using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public class UserService
    {
        public List<Customer> Customers { get; set; }
        public List<Employee> Employees { get; set; }

        public UserService()
        {
            Customers = MockUsers.GetMockCustomers();
            Employees = MockUsers.GetMockEmployees();
        }
    }
}
