namespace Classroom.Web.Data;

public class UserRoom
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public Guid RoomId { get; set; }
    public virtual Classroom? Room { get; set; }
}