using classroom.Controllers;
using Microsoft.AspNetCore.Identity;

namespace classroom.Entities;

public class User: IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long CHatId { get; set; }
    public ushort Step { get; set; }
    public string? PhotoUrl { get; set; }
    public int MyProperty { get; set; }
    public virtual ICollection<UserRoom>? Users { get; set; }
}