using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wagevo.Models;

public class Shift
{
    [Key]
    public int ShiftId { get; set; }  // Primary Key
    public int  UserId { get; set; }
    public DateTime TimeIn { get; set; }
    public DateTime TimeOut { get; set; }
    public double HoursWorked { get; set; }
    public double Earnings { get; set; }
    [ForeignKey("UserId")]
    [Required]
    public User User { get; set; }
}