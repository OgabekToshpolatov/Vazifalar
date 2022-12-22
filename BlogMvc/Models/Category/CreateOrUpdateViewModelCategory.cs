using System.ComponentModel.DataAnnotations;

namespace BlogMvc.Models.Category;

public class CreateOrUpdateViewModelCategory
{
    [Required(ErrorMessage ="Name is required")]
    public string Name { get; set; }
}