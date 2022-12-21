using BlogMvc.Models.Category;

namespace BlogMvc.Models.Job;

public class CreateOrUpdateJobViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Company { get; set; }
    public string PhoneNumber { get; set; }
    public long CategoryId { get; set; }
    public IFormFile Image { get; set; }
}