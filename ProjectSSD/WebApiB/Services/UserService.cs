using Microsoft.EntityFrameworkCore;
using Models;
using WebApiB.Data;
using WebApiB.Dtos;

namespace WebApiB.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext db)
    {
        _context = db;
    }

    public async Task SaveUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserGetDto>> GetAllUsersAsync()
    {
        var users = await _context.Users.AsNoTracking().ToListAsync();
        var userDtos = users.Select(user => ConvertToUserDto(user));
        return userDtos;
    }

    private UserGetDto ConvertToUserDto(User user)
    {
        return new UserGetDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }

    public async Task<UserGetDto> UserByIdAsync(int id)
    {
        var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return null;

        return ConvertToUserDto(user);
    }
    
}
