using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DotNetTodoAPI.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(100, ErrorMessage = "UserName length cannot exceed 100 characters")]
        public string UserName { get; set; }

        public ICollection<Todo> Todos { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}