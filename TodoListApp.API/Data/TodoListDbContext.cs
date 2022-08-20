using Microsoft.EntityFrameworkCore;
using Task = TodoListApp.API.Entities.Task;

namespace TodoListApp.API.Data
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
