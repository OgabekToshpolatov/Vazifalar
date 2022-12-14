using System.ComponentModel.DataAnnotations;

namespace BlogMvc.Models;

public class PostViewModel
{
    public long Id { get; set; }
    [Required(ErrorMessage ="Name is required")]
    public string Name { get; set; }
    public string Address { get; set; }

    [Required(ErrorMessage ="PhoneNumber is required")]
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string AppUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsEdited { get; set; }
}