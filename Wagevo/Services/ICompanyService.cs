using Wagevo.Models;

namespace Wagevo.Services;

public interface ICompanyService
{
    Company AddCompany(Company company);
    
    List<User> GetEmployees(int companyId);
}