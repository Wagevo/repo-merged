namespace Wagevo.Models;

public class User
{
    public int UserId { get; set; }  // Primary Key
    public int  CompanyId { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime DateCreated { get; set; }
    public string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
    public double HourlyWage { get; set; }
    public required string Password { get; set; }
}