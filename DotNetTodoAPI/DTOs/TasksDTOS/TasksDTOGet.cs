namespace DotNetTodoAPI.DTOs
{
    public class TasksDTOGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public int TodoId { get; set; }
    }
}
