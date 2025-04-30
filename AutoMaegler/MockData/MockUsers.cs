using AutoMaegler.Models;

namespace AutoMaegler.MockData
{
    public class MockUsers
    {
        private static List<Employee> Employees = new List<Employee>
        {
            new Employee(1, "Oliver Kronborg", "Salesman", 23098543, "Okronborg@gmail.com", "123")
            
        };

        private static List<Customer> Customers = new List<Customer>
        {
            new Customer(101, "Lars Larsen", 12456790, "LLarsen@gmail.com", "123", "Bovej 9", true)
            
        };

        public static List<Employee> GetMockEmployees()
        {
            return Employees;
        }

        public static List<Customer> GetMockCustomers()
        {
            return Customers;
        }
    }
}
