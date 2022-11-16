namespace Classroom.Web.Data;

public class UserTask
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public Guid TaskId { get; set; }
    public virtual Task? Task { get; set; }
    public EUserTaskStatus Status { get; set; }
    public string? Commit { get; set; }
    public string? Url { get; set; }

    public virtual ICollection<UserTaskComment>? Comments { get; set; }
}