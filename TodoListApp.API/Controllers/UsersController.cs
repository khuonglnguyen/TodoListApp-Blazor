using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoListApp.API.Repositories;

namespace TodoListApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetUserList();
            var assignees = users.Select(x => new AssigneeDto()
            {

                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName
            });

            return Ok(assignees);
        }
    }
}
