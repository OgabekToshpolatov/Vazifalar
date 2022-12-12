using BlogMvc.Models.Job;

namespace BlogMvc.Services;

public interface IJobsService
{
    Task DeleteJobAsync(long id);
    Task<JobViewModel> GetJobByIdAsync(long id);
    Task<JobViewModel> CreateJobAsync(CreateOrUpdateJobViewModel model);
}