namespace classroom.Entities;

public class Science
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public School? School { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedDate {get; set;}
    public DateTime? StartDate {get; set;}
    public DateTime? EndDate {get; set;}
    public ESicenceStatus Status { get; set; }
}