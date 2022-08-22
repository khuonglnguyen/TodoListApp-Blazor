using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoListApp.API.Data;

namespace TodoListApp.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDbContext _context;

        public TaskRepository(TodoListDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Entities.Task>> GetTaskList(TaskListSearch taskListSearch)
        {

            var query = _context.Tasks.Include(x => x.Assignee).AsQueryable();
            if (!string.IsNullOrEmpty(taskListSearch.Name))
            {
                query = query.Where(x => x.Name.Contains(taskListSearch.Name));
            }
            if (taskListSearch.AssigneeId.HasValue)
            {
                query = query.Where(x => x.AssigneeId == taskListSearch.AssigneeId.Value);
            }
            if (taskListSearch.Priority.HasValue)
            {
                query = query.Where(x => x.Priority == taskListSearch.Priority.Value);
            }

            return await query.OrderByDescending(x=>x.CreatedDate).ToListAsync();
        }

        public async Task<Entities.Task> Create(Entities.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> Update(Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> Delete(Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }
    }
}
