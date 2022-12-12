namespace BlogMvc.Models.Job;

public class CreateOrUpdateJobViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public long PostId { get; set; }
    public IFormFile Image { get; set; }
}