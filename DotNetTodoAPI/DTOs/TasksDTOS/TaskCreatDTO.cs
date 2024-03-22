using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTodoAPI.DTOs.TasksDTOS
{
    public class TaskCreatDTO
    {
        public string Name { get; set; }

        [EnumDataType(typeof(PriorityEnum), ErrorMessage = "Priority must be Low, Medium, or High")]
        public string Priority { get; set; }
        public int TodoId { get; set; } 
    }

    public enum PriorityEnum
    {
        Low,
        Medium,
        High
    }
}
