using Microsoft.AspNetCore.Mvc;
using WebApiB.Dtos;
using WebApiB.Services;

namespace WebApiB.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserGetDto>>> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserGetDto>> GetUserById(int id)
    {
        var user = await _userService.UserByIdAsync(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }
}