namespace Wagevo.Services;
using Wagevo.Data;
using Wagevo.Models;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly WagevoDBContext _context;

    public UserService(WagevoDBContext context)
    {
        _context = context;
    }

    public async Task<User> AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }
}
