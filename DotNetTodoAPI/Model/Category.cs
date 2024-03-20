using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DotNetTodoAPI.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name length cannot exceed 100 characters")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Description length cannot exceed 255 characters")]
        public string Description { get; set; }
        public ICollection<TodoCategory> TodoCategories { get; set; }
    }
}