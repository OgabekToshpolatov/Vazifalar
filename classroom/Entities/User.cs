using classroom.Controllers;

namespace classroom.Entities;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long CHatId { get; set; }
    public ushort Step { get; set; }
    public string? PhotoUrl { get; set; }
    public int MyProperty { get; set; }


    public virtual ICollection<UserRoom>? Users { get; set; }
}