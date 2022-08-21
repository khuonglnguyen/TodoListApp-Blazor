using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TodoListApp.API.Entities
{
    public class Role : IdentityRole<Guid>
    {
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
