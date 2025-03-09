using System.ComponentModel.DataAnnotations;

namespace Wagevo.Models;

public class Company
{
    [Key]
    public int  CompanyId { get; set; } // Primary Key
    public string Name { get; set; }
    public required string Address { get; set; }
}