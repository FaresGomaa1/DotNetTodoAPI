using DotNetTodoAPI.DTOs;
using DotNetTodoAPI.Migrations;
using DotNetTodoAPI.Model;
using DotNetTodoAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetTodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodo _todoRepository;
        private readonly ITodoCategory _todoCategoryRepository;
        private readonly ICategory _categoryRepository;
        private readonly ITasks _tasksRepository;

        public TodoController(ITodo todoRepository, ITodoCategory todoCategoryRepository, ICategory categoryRepository, ITasks tasksRepository)
        {
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
            _todoCategoryRepository = todoCategoryRepository ?? throw new ArgumentNullException(nameof(todoCategoryRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _tasksRepository = tasksRepository ?? throw new ArgumentNullException(nameof(tasksRepository));
        }

        // GET: api/Todo
        [HttpGet]
        public IActionResult GetAllTodos()
        {
            IEnumerable<Todo> todos = _todoRepository.GetAll();
            IEnumerable<TodoDto> todoDtos = todos.Select(todo => new TodoDto
            {
                TodoId = todo.TodoId,
                TodoTitle = todo.TodoTitle,
                TodoStatus = todo.TodoStatus,
                Tasks = _tasksRepository.GetAll().Where(task => task.TodoId == todo.TodoId)
                                                  .Select(task => new TasksDTOGet
                                                  {
                                                      Id = task.Id,
                                                      Name = task.Name,
                                                      Priority = task.Priority
                                                  }).ToList(),
                Category = _todoCategoryRepository.GetAllTodoCategories()
                                                  .Where(tc => tc.TodoId == todo.TodoId)
                                                  .Select(tc => new TodoCategoryDto
                                                  {
                                                      TodoId = tc.TodoId,
                                                      CategoryId = tc.CategoryId
                                                  }).ToList()
            });

            return Ok(todoDtos);
        }


        // GET: api/Todo/5
        [HttpGet("{id}")]
        public IActionResult GetTodoById(int id)
        {
            Todo todo = _todoRepository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            // Retrieve tasks for the todo
            IEnumerable<TasksDTOGet> tasks = _tasksRepository.GetAll().Where(task => task.TodoId == todo.TodoId)
                                                                      .Select(task => new TasksDTOGet
                                                                      {
                                                                          Id = task.Id,
                                                                          Name = task.Name,
                                                                          Priority = task.Priority
                                                                      }).ToList();

            // Retrieve categories for the todo
            IEnumerable<TodoCategoryDto> categories = _todoCategoryRepository.GetAllTodoCategories()
                                                                               .Where(tc => tc.TodoId == todo.TodoId)
                                                                               .Select(tc => new TodoCategoryDto
                                                                               {
                                                                                   TodoId = tc.TodoId,
                                                                                   CategoryId = tc.CategoryId
                                                                               }).ToList();

            TodoDto todoDto = new TodoDto
            {
                TodoId = todo.TodoId,
                TodoTitle = todo.TodoTitle,
                TodoStatus = todo.TodoStatus,
                Tasks = tasks.ToList(),
                Category = categories.ToList()
            };

            return Ok(todoDto);
        }


        // POST: api/Todo
        [HttpPost]
        public IActionResult CreateTodo([FromBody] AddTodoDto todoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Todo todo = new Todo
            {
                TodoTitle = todoDto.TodoTitle,
                TodoStatus = todoDto.TodoStatus
            };

            _todoRepository.Add(todo);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.TodoId }, todoDto);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, [FromBody] AddTodoDto todoDto)
        {
            try
            {
                Todo todo = _todoRepository.GetById(id);
                if (todo == null)
                {
                    return NotFound("Todo not found");
                }

                todo.TodoTitle = todoDto.TodoTitle;
                todo.TodoStatus = todoDto.TodoStatus;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _todoRepository.Update(todo);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            _todoRepository.Delete(id);
            return NoContent();
        }
    }
}