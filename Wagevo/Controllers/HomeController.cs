using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    private readonly IFinchAPIService _finchAPIService;

    public HomeController(ILogger<HomeController> logger, IUserService userService, ICompanyService companyService, IFinchAPIService finchAPIService)
    {
        _logger = logger;
        _userService = userService;
        _companyService = companyService;
        _finchAPIService = finchAPIService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login(RegistrationForm form)
    {
        string email = form.Email;
        string password = form.Password;
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return View();
        User user = _userService.GetUserByEmailAndPassword(email, password);
        return user == null ?  View() : 
            RedirectToAction("Index", "Company", new { companyId=user.CompanyId });
    }

    public IActionResult Register()
    {
        return View();
    }

    public async Task<IActionResult> Registration(RegistrationForm form)
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
            HourlyWage = 0,
            PhoneNumber = form.Phone,
            IsAdmin = true
        };
        _userService.AddUser(user);
        try
        {
            string responseData = await _finchAPIService.GetEmployeesAsync();
            using JsonDocument doc = JsonDocument.Parse(responseData);
            JsonElement individualsElement = doc.RootElement.GetProperty("individuals");
            var users = JsonSerializer.Deserialize<List<UserDTO>>(individualsElement.GetRawText(), 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            foreach (var person in users)
            {
                _userService.AddUser(new User()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    CompanyId = company.CompanyId,
                    IsAdmin = false,
                    HourlyWage = 25,
                    PhoneNumber = "8018784949",
                    Email = person.FirstName + "@" + person.LastName,
                    Password = "standardPassword"
                });
            }
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Company", company);
        }
        return RedirectToAction("Index", "Company", company);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public class UserDTO
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}