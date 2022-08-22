using Microsoft.EntityFrameworkCore;
using TodoListApp.API.Data;
using TodoListApp.API.Entities;

namespace TodoListApp.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoListDbContext _context;

        public UserRepository(TodoListDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
