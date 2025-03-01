using Wagevo.Models;

namespace Wagevo.Services;

public interface IUserService
{
    Task<User> AddUser(User user);
    Task<List<User>> GetAllUsers();
}