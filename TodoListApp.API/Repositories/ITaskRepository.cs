
namespace TodoListApp.API.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetTaskList();

        Task<Entities.Task> Create(Entities.Task task);

        Task<Entities.Task> Update(Entities.Task task);

        Task<Entities.Task> Delete(Entities.Task task);

        Task<Entities.Task> GetById(Guid id);
    }
}
