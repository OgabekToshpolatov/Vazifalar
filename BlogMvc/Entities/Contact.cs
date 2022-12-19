using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogMvc.Entities;

public class Contact
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
    public string Email { get; set; }
    public DateTime SendData { get; set; } = DateTime.UtcNow;
}