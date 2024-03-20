using DotNetTodoAPI.Model;
using System.Collections.Generic;

namespace DotNetTodoAPI.Repo
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
