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

    public HomeController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
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
        User user = new User()
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            Password = form.Password,
            Birthday = form.Birthday,
            CompanyId = 1,
            HourlyWage = 1,
            PhoneNumber = form.Phone,
            IsAdmin = true
        };
        _userService.AddUser(user);
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}