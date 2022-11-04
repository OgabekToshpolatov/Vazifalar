namespace claim.Services;

public class UserJsonList
{
    public Dictionary<string, User> Users { get; set; }

    public UserJsonList()
    {
        Users = new Dictionary<string, User>();
    }
}

public class User
{
    public string? Name { get; set; }
    public string? Role { get; set; }
}