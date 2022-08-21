using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListApp.API.Entities;
using Task = TodoListApp.API.Entities.Task;

namespace TodoListApp.API.Data
{
    public class TodoListDbContext : IdentityDbContext<User, Role,Guid>
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
