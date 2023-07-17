#pragma warning disable CS8618
namespace ProductAndCategories.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


public class Product
{    
    [Key]    
    public int ProductId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set;}

    [Required]
    public decimal? Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> AssociationsFromProducts { get; set; } = new List<Association>();
}
