namespace DotNetTodoAPI.Repo
{
    public interface ITodoCategory
    {
        void AddTodoCategory(int todoId, int categoryId);
        void RemoveTodoCategory(int todoId, int categoryId);
    }
}
