#pragma warning disable CS8618
namespace ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations;

public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date Of Birth")]
    [FutureDate]
    [AdultAge]
    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> AllDishes { get; set; } = new List<Dish>();


    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Must enter a Date of Birth!");
            }
            else if ((DateTime)value > DateTime.Now)
            {
                return new ValidationResult("Birthday must be in the past!");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }

    public class AdultAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Must enter a Date of Birth!");
            }
            int age = (int)((DateTime.Now - (DateTime)value).TotalDays / 365.242199);
            if (age < 18)
            {
                return new ValidationResult("You are under 18 years old");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }

}