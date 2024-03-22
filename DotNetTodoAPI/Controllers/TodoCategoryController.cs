using DotNetTodoAPI.DTOs;
using DotNetTodoAPI.Model;
using DotNetTodoAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DotNetTodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoCategoryController : ControllerBase
    {
        private readonly ITodoCategory _todoCategoryRepository;

        public TodoCategoryController(ITodoCategory todoCategoryRepository)
        {
            _todoCategoryRepository = todoCategoryRepository ?? throw new ArgumentNullException(nameof(todoCategoryRepository));
        }

        // POST: api/TodoCategory
        [HttpPost]
        public IActionResult AddTodoCategory([FromBody] TodoCategoryDto todoCategoryDto)
        {
            try
            {
                if (todoCategoryDto.TodoId <= 0 || todoCategoryDto.CategoryId <= 0)
                {
                    return BadRequest("Invalid TodoId or CategoryId");
                }

                _todoCategoryRepository.AddTodoCategory(todoCategoryDto.TodoId, todoCategoryDto.CategoryId);
                return Ok("TodoCategory added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding TodoCategory: {ex.Message}");
            }
        }

        // DELETE: api/TodoCategory/5/3
        [HttpDelete("{todoId}/{categoryId}")]
        public IActionResult RemoveTodoCategory(int todoId, int categoryId)
        {
            try
            {
                _todoCategoryRepository.RemoveTodoCategory(todoId, categoryId);
                return Ok("TodoCategory removed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error removing TodoCategory: {ex.Message}");
            }
        }
    }
}