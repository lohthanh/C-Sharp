#pragma warning disable CS8618
namespace ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations;

public class Dish
{    
    [Key]    
    public int DishId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    [Display(Name = "Number of Calories")]
    [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
    public int? NumOfCalories { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "The value must be between 1 and 5")]
    public int? Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId { get; set; }
    public Chef? Creator { get; set; }
}
