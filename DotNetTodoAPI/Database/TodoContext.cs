using DotNetTodoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoAPI.Database
{
    public class TodoContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoCategory> TodoCategories { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoCategory>()
                .HasKey(tc => tc.TodoId);

            modelBuilder.Entity<TodoCategory>()
                .HasOne(tc => tc.Todo)
                .WithMany(t => t.TodoCategories)
                .HasForeignKey(tc => tc.TodoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TodoCategory>()
                .HasOne(tc => tc.Category)
                .WithMany(c => c.TodoCategories)
                .HasForeignKey(tc => tc.CategoryId);
        }
    }
}