using Wagevo.Models;

namespace Wagevo.Services;

public interface IUserService
{
    User AddUser(User user);
    Task<List<User>> GetAllUsers();
    User GetUserByEmailAndPassword(string email, string password);
}