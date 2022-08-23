using TodoList.Models;

namespace TodoListApp.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList();
        Task<TaskDto> GetTaskDetail(string id);
        Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch);
        Task<bool> CreateTask(TaskCreateRequest request);
        Task<bool> UpdateTask(Guid id, TaskUpdateRequest request);
        Task<bool> DeleteTask(Guid id);
    }
}
