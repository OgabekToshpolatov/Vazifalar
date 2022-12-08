using System.ComponentModel.DataAnnotations;

namespace mvc.Dtos;

public class UpdateCategoryDto
{
    [Required]
    public string? Name { get; set; }
    public int? ParentId { get; set; }
}