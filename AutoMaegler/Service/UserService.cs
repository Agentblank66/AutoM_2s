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
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            //Skal være generisk når det skal laves
            //JsonFileService.SaveJsonObjects(Users);
        }

    }
}
