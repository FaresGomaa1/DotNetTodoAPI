using System.ComponentModel.DataAnnotations;

namespace DotNetTodoAPI.DTOs.CategoryDTOS
{
    public class CategoryDtoAdd
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name length cannot exceed 100 characters")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Description length cannot exceed 255 characters")]
        public string Description { get; set; }
    }
}