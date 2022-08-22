using TodoList.Models;

namespace TodoListApp.Services
{
    public interface IUserApiClient
    {
        Task<List<AssigneeDto>> GetAssignees();
    }
}
