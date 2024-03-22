using System;
using System.Collections.Generic;
using System.Linq;
using DotNetTodoAPI.Database;
using DotNetTodoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoAPI.Repo
{
    public class TodoRepo : ITodo
    {
        private readonly TodoContext _context;

        public TodoRepo(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos.Include(t => t.Tasks)
                                  .Include(t => t.Attachments)
                                  .Include(t => t.TodoCategories)
                                  .ToList();
        }

        public Todo GetById(int id)
        {
            return _context.Todos.Include(t => t.Tasks)
                                  .Include(t => t.Attachments)
                                  .Include(t => t.TodoCategories)
                                  .FirstOrDefault(t => t.TodoId == id);
        }

        public void Add(Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Update(Todo todo)
        {
            var existingTodo = GetById(todo.TodoId);
            if (existingTodo == null)
            {
                throw new InvalidOperationException("Todo not found");
            }

            existingTodo.TodoTitle = todo.TodoTitle;
            existingTodo.TodoStatus = todo.TodoStatus;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var todoToRemove = GetById(id);
            if (todoToRemove != null)
            {
                _context.Todos.Remove(todoToRemove);
                _context.SaveChanges();
            }
        }
    }
}