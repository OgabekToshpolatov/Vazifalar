namespace mvc.Entities;

public class Organization
{
    public Guid Id { get; set; }
    public string? Name {get;set;}
    public string? ImagePath {get;set;}
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public EOrganizationStatus Status {get;set;}
    public virtual ICollection<OrganizationUser>? Users { get; set; }
    public virtual ICollection<Job>? Jobs { get; set; }

}