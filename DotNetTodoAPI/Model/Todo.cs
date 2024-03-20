using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DotNetTodoAPI.Model
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }

        [Required(ErrorMessage = "TodoTitle is required")]
        [StringLength(200, ErrorMessage = "TodoTitle length cannot exceed 200 characters")]
        public string TodoTitle { get; set; }

        [StringLength(50, ErrorMessage = "TodoStatus length cannot exceed 50 characters")]
        public string TodoStatus { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<TodoCategory> TodoCategories { get; set; }
    }
}