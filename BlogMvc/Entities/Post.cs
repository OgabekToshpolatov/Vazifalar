using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlogMvc.Entities;

public class Post
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string AppUserId { get; set; }

    [ForeignKey(nameof(AppUserId))]
    public AppUser Author { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public bool IsEdited { get; set; } = false;
}