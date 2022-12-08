namespace mvc.Entities;

public class Organization
{
    public Guid Id { get; set; }
    public string? Name {get;set;}
    public EOrganizationStatus Status {get;set;}
    public virtual ICollection<Job>? Jobs { get; set; }

}