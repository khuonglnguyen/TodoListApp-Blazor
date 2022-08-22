using TodoList.Models;

namespace TodoListApp.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList();
        Task<TaskDto> GetTaskDetail(string id);
        Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch);
    }
}
