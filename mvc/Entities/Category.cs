using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Entities;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ParnetId { get; set; }
    [ForeignKey(nameof(ParnetId))]
    public virtual Category? Parent { get; set; }
    public virtual List<Category>? Children { get; set; }
    public virtual ICollection<Job>? Jobs { get; set; }
}