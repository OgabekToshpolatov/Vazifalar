using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Entities;

public class Job
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public int? CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public virtual Category? Category { get; set; }
    public Guid OrganizationId { get; set; }
    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization? Organization { get; set; }
}