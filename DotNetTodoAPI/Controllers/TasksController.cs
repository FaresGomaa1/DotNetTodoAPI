using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetTodoAPI.DTOs.TasksDTOS;
using DotNetTodoAPI.DTOs;
using DotNetTodoAPI.Model;
using DotNetTodoAPI.Repo;
using System;
using System.Collections.Generic;
using Azure.Core;
using System.Threading.Tasks;

namespace DotNetTodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasks _tasksRepository;
        private readonly ITodo _todoRepository;
        public TasksController(ITasks tasksRepository, ITodo todoRepository)
        {
            _tasksRepository = tasksRepository ?? throw new ArgumentNullException(nameof(tasksRepository));
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
        }

        // GET: api/Tasks
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            IEnumerable<Tasks> tasks = _tasksRepository.GetAll();
            IEnumerable<TasksDTOGet> taskDtos = tasks.Select(task => new TasksDTOGet
            {
                Id = task.Id,
                Name = task.Name,
                Priority = task.Priority,
                TodoId = task.TodoId
            }) ;

            return Ok(taskDtos);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            Tasks task = _tasksRepository.GetById(id);
            if (task == null)
            {
                return NotFound();
            }

            TasksDTOGet taskDto = new TasksDTOGet
            {
                Id = task.Id,
                Name = task.Name,
                Priority = task.Priority,
                TodoId = task.TodoId
            };

            return Ok(taskDto);
        }

        // POST: api/Tasks
        [HttpPost]
        public IActionResult AddTask([FromBody] TaskCreatDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = new Tasks
            {
                Name = taskDTO.Name,
                Priority = taskDTO.Priority,
                TodoId = taskDTO.TodoId
            };
            var Todoid = _todoRepository.GetById(task.TodoId);
            if (Todoid == null)
            {
                return BadRequest("Todo Id doesn't exist");
            }

            _tasksRepository.Add(task);

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, taskDTO);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskCreatDTO taskDTO)
        {
            var TaskId = _tasksRepository.GetById(id);
            if (TaskId == null)
            {
                return BadRequest("Task Id doesn't exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingTask = _tasksRepository.GetById(id);

            existingTask.Name = taskDTO.Name;
            existingTask.Priority = taskDTO.Priority;
            var Todoid = _todoRepository.GetById(taskDTO.TodoId);
            if (Todoid == null)
            {
                return BadRequest("Todo Id doesn't exist");
            }

            _tasksRepository.Update(existingTask);

            return NoContent();
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var existingTask = _tasksRepository.GetById(id);

            if (existingTask == null)
            {
                return NotFound();
            }

            _tasksRepository.Delete(id);

            return NoContent();
        }
    }
}