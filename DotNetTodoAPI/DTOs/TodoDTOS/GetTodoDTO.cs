namespace DotNetTodoAPI.DTOs
{
    public class TodoDto
    {
        public int TodoId { get; set; }

        public string TodoTitle { get; set; }

        public string TodoStatus { get; set; }
        public List<TasksDTOGet>? Tasks { get; set; }
        public List<TodoCategoryDto>? Category { get; set; }
    }
}
