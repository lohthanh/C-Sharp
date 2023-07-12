namespace DateValidator.Models;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618


public class User
{
    public string Name { get; set; }

    // [Required (ErrorMessage = "Date of Birth is required!")]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime? Birthday { get; set; }


    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // You first may want to unbox "value" here and cast to to a DateTime variable!    
            // DateTime CurrentDate = DateTime.Today;
            //     // int CompareDate = DateTime.Compare((DateTime)value, CurrentDate);
            //     if (CompareDate >= 0)
            //     {
            //         return new ValidationResult("Date must be in the past!");
            //     }
            //     return ValidationResult.Success;
            // }
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


}


