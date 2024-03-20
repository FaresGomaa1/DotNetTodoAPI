using System;
using System.Linq;
using DotNetTodoAPI.Database;
using DotNetTodoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoAPI.Repo
{
    public class UserRepo :IUser
    {
        private readonly TodoContext _context;

        public UserRepo(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var existingUser = GetById(user.UserId);
            if (existingUser == null)
            {
                throw new InvalidOperationException("User not found");
            }

            existingUser.UserName = user.UserName;
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var userToRemove = GetById(userId);
            if (userToRemove != null)
            {
                _context.Users.Remove(userToRemove);
                _context.SaveChanges();
            }
        }

        public User GetById(int userId)
        {
            return _context.Users.Include(u => u.Todos)
                                  .Include(u => u.Categories)
                                  .FirstOrDefault(u => u.UserId == userId);
        }
    }
}