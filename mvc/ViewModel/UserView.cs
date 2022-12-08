using mvc.Entities;

namespace mvc.ViewModel;

public class UserView
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public EUserStatus Status { get; set; }
    
}
