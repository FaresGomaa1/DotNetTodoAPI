using DotNetTodoAPI.Model;
using System.Collections.Generic;

namespace DotNetTodoAPI.Repo
{
    public interface ITodo
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        void Add(Todo todo);
        void Update(Todo todo);
        void Delete(int id);
    }
}
