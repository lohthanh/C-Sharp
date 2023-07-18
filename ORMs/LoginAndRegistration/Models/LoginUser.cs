using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndRegistration.Models;

[NotMapped]
public class LoginUser
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? LoginEmail { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? LoginPassword { get; set; }

}