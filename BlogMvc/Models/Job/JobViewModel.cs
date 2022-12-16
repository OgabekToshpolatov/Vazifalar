namespace BlogMvc.Models.Job;

public class JobViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public DateTime CreatedDate { get; set; }
    public long CategoryId { get; set; }
    public long PostId { get; set; }
}