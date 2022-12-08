using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Entities;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public virtual Category? Parent { get; set; }
    public virtual List<Category>? Children { get; set; }
    public virtual ICollection<Job>? Jobs { get; set; }
}