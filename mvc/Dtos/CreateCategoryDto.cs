using System.ComponentModel.DataAnnotations;

namespace mvc.Dtos;

public class CreateCategoryDto
{
    [Required]
    public string? Name { get; set; }
    public int? ParentId { get; set; }
}