using mvc.Entities;

namespace mvc.Models;

public class OrganizationModel
{
    public Guid Id { get; set; }
    public string? Name {get;set;}
    public string? ImagePath {get;set;}
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public EOrganizationStatus Status {get;set;}
}