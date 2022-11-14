namespace classroom.Entities;

public class UserTask
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int TaskId { get; set; }
    public Task? Task { get; set; }
    public EUserTaskStatus Status { get; set; }
    public string? Commit { get; set; }
    public string? Url { get; set; }
    public ushort Ball { get; set; }
    public virtual ICollection<UserTaskComment>? Comments { get; set; }
}