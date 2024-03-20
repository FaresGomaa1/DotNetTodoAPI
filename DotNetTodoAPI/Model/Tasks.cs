using System.ComponentModel.DataAnnotations;

namespace DotNetTodoAPI.Model
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name length cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        [StringLength(50, ErrorMessage = "Priority length cannot exceed 50 characters")]
        public string Priority { get; set; }
    }
}
