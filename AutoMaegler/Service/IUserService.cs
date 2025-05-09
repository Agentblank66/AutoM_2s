using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public interface IUserService
    {
        List<User> GetUsers();
        void AddUser(Customer customer, Employee employee;
        void DeleteUser( Customer customer, Employee employee);
        void UpdateUser(Customer customer, Employee employee);
        User GetUserById(int id);
        IEnumerable<User> SearchbyName();
       
        

    }
}
