using AutoMaegler.MockData;
using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public class UserService: IUserService
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
        public void AddUser(Customer customer, Employee employee)
        {
            if (customer != null) 
            {
                Customers.Add(customer);
                //Skal være generisk når det skal laves
                //JsonFileService.SaveJsonObjects(Users);
            }
            else if(employee != null)
            {
                Employees.Add(employee);
                //JsonFileService.SaveJsonObjects(Users);
            }
        }

        public User DeleteUser(Customer customer, Employee employee)
        {
            if()
            {
                Customers.Remove(customer);
                //JsonFileService.SaveJsonObjects(Users);
            }

        }

        public List<T> GetUsers<T>() where T : User
        {
            
        }
       
        public void UpdateUser(Customer customer, Employee employee)
        {

        }
        public User GetUserById(int id)
        {

        }
        public IEnumerable<User> SearchbyName()
        {

        }
    }
}
