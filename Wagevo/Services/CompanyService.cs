using Wagevo.Data;
using Wagevo.Models;

namespace Wagevo.Services;

public class CompanyService: ICompanyService
{
    private WagevoDBContext _context;

    public CompanyService(WagevoDBContext context)
    {
        _context = context;
    }
    public Company AddCompany(Company company)
    {
        _context.Companies.Add(company);
        _context.SaveChanges();
        return company;
    }
}