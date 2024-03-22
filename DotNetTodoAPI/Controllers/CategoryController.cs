using DotNetTodoAPI.DTOs;
using DotNetTodoAPI.DTOs.CategoryDTOS;
using DotNetTodoAPI.Model;
using DotNetTodoAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace DotNetTodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryRepository;
        private readonly ITodoCategory _TodoCategoryRepository;
        public CategoryController(ICategory categoryRepository, ITodoCategory TodoCategoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _TodoCategoryRepository = TodoCategoryRepository ?? throw new ArgumentNullException(nameof(TodoCategoryRepository));
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll();
            IEnumerable<CategoryDtoGet> categoryDtos = categories.Select(category => new CategoryDtoGet
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                TodoCategories = _TodoCategoryRepository.GetAllTodoCategories().Where(tc => tc.CategoryId == category.Id)
                                                                                .Select(tc => new TodoCategoryDto
                                                                                {
                                                                                    TodoId = tc.TodoId,
                                                                                    CategoryId = tc.CategoryId
                                                                                })
                                                                                .ToList()
            });

            return Ok(categoryDtos);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            CategoryDtoGet categoryDto = new CategoryDtoGet
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                TodoCategories = _TodoCategoryRepository.GetAllTodoCategories().Where(tc => tc.CategoryId == category.Id)
                                                                                .Select(tc => new TodoCategoryDto
                                                                                {
                                                                                    TodoId = tc.TodoId,
                                                                                    CategoryId = tc.CategoryId
                                                                                })
                                                                                .ToList()
            };

            return Ok(categoryDto);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDtoAdd categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            _categoryRepository.Add(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDtoAdd categoryDto)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound("Category ID not found");
            }

            try
            {
                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _categoryRepository.Update(category);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
            return NoContent();
        }
    }
}