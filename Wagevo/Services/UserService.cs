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

    public User GetUserById(int userId)
    {
        User user = _context.Users.Where(user => user.UserId == userId).FirstOrDefault();
        return user;
    }

    public User UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return user;
    }

    public List<Shift> GetShiftsByUserId(int userId)
    {
        List<Shift> shifts = _context.Shifts.Where(shift => shift.UserId == userId).ToList();
        return shifts;
    }

    public Shift UpdateShift(Shift shift)
    {
        _context.Shifts.Update(shift);
        _context.SaveChanges();
        return shift;
    }
}
