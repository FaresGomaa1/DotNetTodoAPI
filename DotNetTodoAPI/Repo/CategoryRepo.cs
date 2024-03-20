using System;
using System.Collections.Generic;
using System.Linq;
using DotNetTodoAPI.Database;
using DotNetTodoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoAPI.Repo
{
    public class CategoryRepo : ICategory
    {
        private readonly TodoContext _context;

        public CategoryRepo(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            var existingCategory = GetById(category.Id);
            if (existingCategory == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryToRemove = GetById(id);
            if (categoryToRemove != null)
            {
                _context.Categories.Remove(categoryToRemove);
                _context.SaveChanges();
            }
        }
    }
}
