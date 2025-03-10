using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Wagevo.Models;
using Wagevo.Services;
using UserService = Wagevo.Services.UserService;

namespace Wagevo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;
    private readonly ICompanyService _companyService;

    public HomeController(ILogger<HomeController> logger, IUserService userService, ICompanyService companyService)
    {
        _logger = logger;
        _userService = userService;
        _companyService = companyService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Registration(RegistrationForm form)
    {
        Company company = new Company()
        {
            Address = form.BusinessAddress,
            Name = form.BusinessName,
        };
        _companyService.AddCompany(company);
        User user = new User()
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            Password = form.Password,
            Birthday = form.Birthday,
            CompanyId = company.CompanyId,
            HourlyWage = 1,
            PhoneNumber = form.Phone,
            IsAdmin = true
        };
        _userService.AddUser(user);
        return RedirectToAction("Index", "Company", company);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}