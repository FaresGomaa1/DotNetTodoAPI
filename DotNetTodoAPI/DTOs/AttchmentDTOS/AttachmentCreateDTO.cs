using System.ComponentModel.DataAnnotations;

namespace DotNetTodoAPI.DTOs
{
    public class AttachmentCreateDTO
    {
        [Required(ErrorMessage = "FilePath is required")]
        [StringLength(255, ErrorMessage = "FilePath length cannot exceed 255 characters")]
        public string FilePath { get; set; }

        [Required(ErrorMessage = "TodoId is required")]
        public int TodoId { get; set; }
    }
}
