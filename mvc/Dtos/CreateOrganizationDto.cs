using System.ComponentModel.DataAnnotations;

namespace mvc.Dtos;

public class CreateOrganizationDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public IFormFile? Image { get; set; }
    public string? Address { get; set; }
    
    [Required]
    public string? PhoneNumber { get; set; }
}