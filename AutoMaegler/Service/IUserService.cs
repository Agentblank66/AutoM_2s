using AutoMaegler.Models;

namespace AutoMaegler.Service
{
    public interface IUserService
    {
        public void AddUser<T>(T user) where T : User;

        public void DeleteUser<T>(T user) where T : User;

        public void UpdateUser(User user);

        public User GetUser(int id, User.UserType? user);

        public List<T> SearchById<T>(int id) where T : User;
        public List<T> SearchbyName<T>(string name) where T : User;

    }
}
