using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace WeddingPlanner.Models;

public class Wedding

{
    [Key]
    public int WeddingId { get; set; }

    [Required(ErrorMessage = "A name is required")]
    public string? WedderOne { get; set; }

    [Required(ErrorMessage = "A name is required")]
    public string? WedderTwo { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime? Date { get; set; }

    [Required]
    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> AssociationsFromWedding { get; set; } = new List<Association>();

    [Required]
    public int UserId { get; set; }



    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Must enter a date!");
            }
            else if ((DateTime)value < DateTime.Now)
            {
                return new ValidationResult("Date cannot be in the past!");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }

}