using AutoMaegler.Models;
using AutoMaegler.Pages.Cars;

namespace AutoMaegler.MockData
{
    public class MockUsers

    {

        private static List<Car> _cars = new List<Car>()
        {
            new Car(1, "Sedan", "Audi", "A6", "Marineblue", "Petrol", 2020, 356000, 60000, 29.5, 250, 4, 299,"Automatic", 4, 2.0, 6.2, 494, 4, 2000, 2085, true),
            new Car(2, "SUV", "Alfa-Romeo", "Stelvio", "Blue", "Petrol", 2019, 350000, 69000, 12.6, 215, 4, 200, "Automatic", 4, 2.0, 7.2, 469, 4, 1600, 1635, true)
        };


        /// <summary>
        /// A privat static list of employees.
        /// </summary>
        private static List<Employee> Employees = new List<Employee>
        {
            new Employee(1, "Oliver Kronborg", "Salesman", 23098543, "Okronborg@gmail.com", "123")
           
        };

        /// <summary>
        /// A privat static list of customers.
        /// </summary>
        private static List<Customer> Customers = new List<Customer>
        {
            new Customer(101, "Lars Larsen", 12456790, "LLarsen@gmail.com", "123", "Bovej 9", true)
            
        };

        /// <summary>
        /// A method which returns a list of employees.
        /// </summary>
        /// <returns>
        /// Returns a list of employees.
        /// </returns>
        public static List<Employee> GetMockEmployees()
        {
            return Employees;
        }

        /// <summary>
        /// A method which returns a list of customers.
        /// </summary>
        /// <returns>
        /// Returns a list of customers.
        /// </returns>
        public static List<Customer> GetMockCustomers()
        {
            return Customers;
        }
    }
}
