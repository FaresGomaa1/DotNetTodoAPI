using System;
using System.Collections.Generic;
using System.Linq;
using DotNetTodoAPI.Database;
using DotNetTodoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoAPI.Repo
{
    public class TasksRepo : ITasks
    {
        private readonly TodoContext _context;

        public TasksRepo(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Tasks> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public Tasks GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Tasks tasks)
        {
            if (tasks == null)
            {
                throw new ArgumentNullException(nameof(tasks));
            }

            _context.Tasks.Add(tasks);
            _context.SaveChanges();
        }

        public void Update(Tasks tasks)
        {
            var existingTasks = GetById(tasks.Id);
            if (existingTasks == null)
            {
                throw new InvalidOperationException("Tasks not found");
            }

            existingTasks.Name = tasks.Name;
            existingTasks.Priority = tasks.Priority;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tasksToRemove = GetById(id);
            if (tasksToRemove != null)
            {
                _context.Tasks.Remove(tasksToRemove);
                _context.SaveChanges();
            }
        }
    }
}