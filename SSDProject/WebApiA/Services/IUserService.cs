using WebApiA.DTOs;

namespace WebApiA.Services
{
    public interface IUserService
    {
        Task CreateUser(UserDto userDto);
    }
}
