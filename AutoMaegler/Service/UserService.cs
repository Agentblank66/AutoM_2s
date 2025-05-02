using AutoMaegler.MockData;
using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public class UserService
    {
        /// <summary>
        /// A public list of customers and employees.
        /// </summary>
        public List<Customer> Customers { get; set; }
        public List<Employee> Employees { get; set; }

        /// <summary>
        /// A constructor which initializes the list of customers and employees.
        /// </summary>
        public UserService()
        {
            Customers = MockUsers.GetMockCustomers();
            Employees = MockUsers.GetMockEmployees();
        }

        /// <summary>
        /// A method which adds a customer to the list of customers.
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            //Skal være generisk når det skal laves
            //JsonFileService.SaveJsonObjects(Users);
        }

    }
}
