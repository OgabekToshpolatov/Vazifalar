namespace classroom.Entities;

public class UserSicence
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int ScienceId {get; set; }
}