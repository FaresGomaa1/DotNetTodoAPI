
using DotNetTodoAPI.Database;
using DotNetTodoAPI.Model;
using DotNetTodoAPI.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNetTodoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TodoContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ITodo, TodoRepo>();
            builder.Services.AddScoped<ICategory, CategoryRepo>();
            builder.Services.AddScoped<ITodoCategory, TodoCategoryRepo>();
            builder.Services.AddScoped<ITasks, TasksRepo>();
            builder.Services.AddScoped<IAttachment, AttachmentRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
