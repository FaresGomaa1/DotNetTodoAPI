using System.ComponentModel.DataAnnotations;

namespace DotNetTodoAPI.Model
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FilePath is required")]
        [StringLength(255, ErrorMessage = "FilePath length cannot exceed 255 characters")]
        public string FilePath { get; set; }
    }
}