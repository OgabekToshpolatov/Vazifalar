using Classroom.Web.Data;

namespace Classroom.Web.Dtos;

public class CreateTaskDto
{
    public string? Description {get; set;}
    public string? Title {get; set;}
    public Guid ClassroomId {get; set;}
    
}