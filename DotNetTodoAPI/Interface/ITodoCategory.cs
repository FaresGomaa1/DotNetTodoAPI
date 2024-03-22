using DotNetTodoAPI.Model;

namespace DotNetTodoAPI.Repo
{
    public interface ITodoCategory
    {
        IEnumerable<TodoCategory> GetAllTodoCategories();
        string GetCategoryNameByTodoId(int todoId);
        void AddTodoCategory(int todoId, int categoryId);
        void RemoveTodoCategory(int todoId, int categoryId);
    }
}
