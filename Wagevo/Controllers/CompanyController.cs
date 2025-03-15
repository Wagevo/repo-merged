using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Wagevo.Models;
using Wagevo.Services;

namespace Wagevo.Controllers;

public class CompanyController: Controller
{
    private readonly ICompanyService _companyService;
    private readonly IUserService _userService;
    
    public CompanyController(ICompanyService companyService, IUserService userService)
    {
        _companyService = companyService;
        _userService = userService;
    }
    
    public IActionResult Index(int companyId)
    {
        Company company = _companyService.GetCompany(companyId);
        ViewBag.Company = company;
        List<User> employees = _companyService.GetEmployees(company.CompanyId);
        ViewBag.Employees = employees;
        return View();
    }
    
    public IActionResult UpdateHourlyWage(int userId, decimal hourlyWage)
    {
        User user = _userService.GetUserById(userId);

        user.HourlyWage = (double)hourlyWage;
        _userService.UpdateUser(user);

        return RedirectToAction("Employee", new { id = user.UserId });
    }

    public IActionResult Employee(int id)
    {
        var user = _userService.GetUserById(id);
        ViewBag.Employee = user;
        ViewBag.Company = _companyService.GetCompany(user.CompanyId);
        return View(user);
    }
}