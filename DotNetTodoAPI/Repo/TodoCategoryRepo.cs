using System;
using System.Linq;
using DotNetTodoAPI.Database;
using DotNetTodoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoAPI.Repo
{
    public class TodoCategoryRepo :ITodoCategory
    {
        private readonly TodoContext _context;

        public TodoCategoryRepo(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddTodoCategory(int todoId, int categoryId)
        {
            var todoCategory = new TodoCategory
            {
                TodoId = todoId,
                CategoryId = categoryId
            };

            _context.TodoCategories.Add(todoCategory);
            _context.SaveChanges();
        }

        public void RemoveTodoCategory(int todoId, int categoryId)
        {
            var todoCategory = _context.TodoCategories.FirstOrDefault(tc => tc.TodoId == todoId && tc.CategoryId == categoryId);
            if (todoCategory != null)
            {
                _context.TodoCategories.Remove(todoCategory);
                _context.SaveChanges();
            }
        }
    }
}