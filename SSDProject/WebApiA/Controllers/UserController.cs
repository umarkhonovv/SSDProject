using Microsoft.AspNetCore.Mvc;
using WebApiA.DTOs;
using WebApiA.Services;

namespace WebApiA.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task Create([FromBody] UserDto userDto)
        {
            await _userService.CreateUser(userDto);
        }
    }
}
