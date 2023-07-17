#pragma warning disable CS8618
namespace ProductAndCategories.Models;
using System.ComponentModel.DataAnnotations;

public class Category
{    
    [Key]    
    public int CategoryId { get; set; }

    [Required]
    public string? Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> AssociationsFromCategory { get; set; } = new List<Association>();
}
