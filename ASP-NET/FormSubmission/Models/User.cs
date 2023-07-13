#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class User
{
    [Required]
    [MinLength(2, ErrorMessage = "Name must have at least 2 characters")]
    public string? Name { get; set; }

    [Required (ErrorMessage = "Email Address is required!")]
    [DataType(DataType.EmailAddress)]
    public string? EmailAddress { get; set; }

    [Required (ErrorMessage = "Date of Birth is required!")]
    [BirthDate]
    public DateTime? DateOfBirth { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Name must have at least 8 characters")]
    public string? Password { get; set; }

    [Required (ErrorMessage = "Must enter a number!")]
    [OddNumber]
    public int? FavoriteOddNumber { get; set; }

    public class BirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null) 
            {
                return new ValidationResult("Must enter a Date of Birth!");
            }

            DateTime CurrentDate = DateTime.Today;
            int CompareDate = DateTime.Compare((DateTime)value, CurrentDate);
            if (CompareDate >= 0)
            {
                return new ValidationResult("Date must be in the past!");
            }
            return ValidationResult.Success;
        }
    }

    public class OddNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Console.WriteLine(value);
            if(value == null) 
            {
                return new ValidationResult("Must enter a number!");
            }
            if (((int)value) % 2 == 0)
            {
                return new ValidationResult("Must be an odd number only!");
            }
                return ValidationResult.Success;
            
        }
    }


}