using BlogMvc.Entities;

namespace BlogMvc.Repositories;

public interface IJobRepository
{
    Task<Job> CreateAsync(Job post);
    Task<Job> GetCategoryAsync(long id);
    Task DeleteAsync(long id);
}