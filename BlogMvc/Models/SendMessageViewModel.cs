using System.ComponentModel.DataAnnotations;

namespace BlogMvc.Models;

public class SendMessageViewModel
{
    [Required(ErrorMessage ="Name is Required")]
    public string Name { get; set; }

    [Required(ErrorMessage ="Message us Required")]
    public string Message { get; set; }

    [Required(ErrorMessage ="Email is Required")]
    public string Email { get; set; }
}