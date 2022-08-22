using TodoList.Models;

namespace TodoListApp.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList();
    }
}
