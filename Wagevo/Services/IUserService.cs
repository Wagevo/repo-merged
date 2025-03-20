using Wagevo.Models;

namespace Wagevo.Services;

public interface IUserService
{
    User AddUser(User user);
    Task<List<User>> GetAllUsers();
    User GetUserByEmailAndPassword(string email, string password);
    User GetUserById(int userId);
    User UpdateUser(User user);
    List<Shift> GetShiftsByUserId(int userId);
    Shift UpdateShift(Shift shift);
}