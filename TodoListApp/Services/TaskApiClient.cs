using System.Net.Http.Json;
using TodoList.Models;

namespace TodoListApp.Services
{
    public class TaskApiClient : ITaskApiClient
    {
        public HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TaskDto>> GetTaskList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>("/api/tasks");
            return result;
        }
    }
}
