using Wagevo.Models;

namespace Wagevo.Services;

public interface IFinchAPIService
{
    public Task<string> GetEmployeesAsync();
}