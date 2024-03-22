    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    namespace DotNetTodoAPI.Model
    {
        public class TodoCategory
        {
            public int TodoId { get; set; }
            public Todo Todo { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
        }
    }
