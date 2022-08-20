using System.ComponentModel.DataAnnotations;
using TodoListApp.API.Enums;

namespace TodoListApp.API.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? Assignee { get; set; }
        public DateTime CreatedDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status{ get; set; }
    }
}
