namespace Wagevo.Services;
using Wagevo.Data;
using Wagevo.Models;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private WagevoDBContext _context;

    public UserService(WagevoDBContext context)
    {
        _context = context;
    }

    public User AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public User GetUserByEmailAndPassword(string email, string password)
    {
        User user = _context.Users
            .Where(user => user.Email == email && user.Password == password)
            .FirstOrDefault();
        return user;
    }
}
