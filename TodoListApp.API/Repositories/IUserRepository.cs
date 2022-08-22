using TodoListApp.API.Entities;

namespace TodoListApp.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserList();
    }
}
