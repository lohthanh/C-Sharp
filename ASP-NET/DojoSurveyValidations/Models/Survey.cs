#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Survey
{   
    [Required]
    [MinLength(2)]
    public string Name {get; set;}

    [Required]
    public string Location {get; set;}

    [Required]
    public string Language {get; set;}
    
    [MinLength(20, ErrorMessage="Must be at least 20 characters long.")]
    public string? Comment {get; set;}
}