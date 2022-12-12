using BlogMvc.Entities;

namespace BlogMvc.Repositories;

public interface IJobRepository
{
    Task<Job> CreateJobAsync(Job post);
    Task<Job> GetJobByIdAsync(long id);
    Task DeleteAsync(long id);
}