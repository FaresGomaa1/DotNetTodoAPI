using System.ComponentModel.DataAnnotations;

namespace DotNetTodoAPI.DTOs
{
    public class AddTodoDto
    {
        [Required(ErrorMessage = "TodoTitle is required")]
        [StringLength(100, ErrorMessage = "TodoTitle length cannot exceed 100 characters")]
        public string TodoTitle { get; set; }

        [Required(ErrorMessage = "TodoStatus is required")]
        [StringLength(50, ErrorMessage = "TodoStatus length cannot exceed 50 characters")]
        public string TodoStatus { get; set; }
    }
}