using DotNetTodoAPI.Model;
using System.Collections.Generic;

namespace DotNetTodoAPI.Repo
{
    public interface ITasks
    {
        IEnumerable<Tasks> GetAll();
        Tasks GetById(int id);
        void Add(Tasks tasks);
        void Update(Tasks tasks);
        void Delete(int id);
    }
}
