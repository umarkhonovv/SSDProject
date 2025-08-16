using Models;
using WebApiB.DTOs;

namespace WebApiB.Services
{
    public interface IUserService
    {
        Task SaveUserAsync(User user);
        Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
    }
}
