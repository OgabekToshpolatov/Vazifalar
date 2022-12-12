using BlogMvc.Models.Job;

namespace BlogMvc.Services;

public interface IJobsService
{
    Task DeleteCategoryAsync(long id);
    Task<JobViewModel> GetCategoryAsync(long id);
    Task<JobViewModel> CreateCategorytAsync(CreateOrUpdateJobViewModel model);
}