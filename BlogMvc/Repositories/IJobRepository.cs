using System.Linq.Expressions;
using BlogMvc.Entities;

namespace BlogMvc.Repositories;

public interface IJobRepository
{
    Task<Job> CreateJobAsync(Job post);
    Task<Job> GetJobByIdAsync(long id);
    Task DeleteAsync(long id);
    Task<IEnumerable<Job>> GetJobsAsync(Expression<Func<Job, bool>> exp);
}