
using TodoList.Models;
using TodoList.Models.SeedWork;

namespace TodoListApp.API.Repositories
{
    public interface ITaskRepository
    {
        Task<PagedList<Entities.Task>> GetTaskList(TaskListSearch taskListSearch);

        Task<Entities.Task> Create(Entities.Task task);

        Task<Entities.Task> Update(Entities.Task task);

        Task<Entities.Task> Delete(Entities.Task task);

        Task<Entities.Task> GetById(Guid id);
        Task<PagedList<Entities.Task>> GetTaskListByUserId(Guid userId, TaskListSearch taskListSearch);
    }
}
