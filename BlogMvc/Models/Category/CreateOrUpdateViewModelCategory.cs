using System.ComponentModel.DataAnnotations;

namespace BlogMvc.Models.Category;

public class CreateOrUpdateViewModelCategory
{
    [Required]
    public string Name { get; set; }
}