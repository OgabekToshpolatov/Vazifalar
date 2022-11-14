namespace classroom.Entities;

public class UserTaskComment
{
    public int Id { get; set; }
    public int UserTaskId { get; set; }
    public UserTask? UserTask { get; set; }
    public string? Message { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime? CreatedAt { get; set; }
}