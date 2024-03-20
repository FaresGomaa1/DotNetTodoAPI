using DotNetTodoAPI.Model;

namespace DotNetTodoAPI.Repo
{
    public interface IUser
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User GetById(int userId);
    }
}
