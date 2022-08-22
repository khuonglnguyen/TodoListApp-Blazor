using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models.Enums;

namespace TodoList.Models
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; } = new Guid();

        [MaxLength(250)]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required]
        public Priority? Priority { get; set; }
    }
}
