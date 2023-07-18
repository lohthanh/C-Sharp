using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618
namespace LoginAndRegistration.Models;
using System.ComponentModel.DataAnnotations.Schema;


public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [Display(Name = "First Name")]
    [MinLength(2,ErrorMessage = "First name must be at least 2 characters!")]
    public string? FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters!")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
    public string? Email { get; set; }

    [Required]
    [MinLength(8,ErrorMessage = "Password must be at least 8 characters!")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [Display(Name = "Confirm Password")]
    [NotMapped]
    [Compare("Password", ErrorMessage = "Password does not match!")]
    public string? ConfirmPassword { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Email is required!");
            }
            MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
            if (_context.Users.Any(e => e.Email == value.ToString()))
            {
                return new ValidationResult("Email must be unique!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }


}