using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Wagevo.Models;
using Wagevo.Services;

namespace Wagevo.Controllers;

public class CompanyController: Controller
{
    private readonly ICompanyService _companyService;
    
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    
    public IActionResult Index(Company company)
    {
        ViewBag.Company = company;
        List<User> employees = _companyService.GetEmployees(company.CompanyId);
        ViewBag.Employees = employees;
        return View();
    }
}