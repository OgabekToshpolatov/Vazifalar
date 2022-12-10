using System.ComponentModel.DataAnnotations.Schema;

namespace BlogMvc.Entities;

public class Job
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public long CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    public long PostId { get; set; }
    [ForeignKey(nameof(PostId))]
    public Post Post { get; set; }
    


}