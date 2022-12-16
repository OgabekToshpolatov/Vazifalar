using BlogMvc.Mapper;
using BlogMvc.Models.Job;
using BlogMvc.Repositories;
using Mapster;

namespace BlogMvc.Services;

public class JobService : IJobsService
{
    private readonly IJobRepository _jobRepository;
    private readonly ILogger<JobService> _logger;

    public JobService(IJobRepository jobRepository, ILogger<JobService> logger) 
    {
        _jobRepository = jobRepository ;
        _logger = logger ;
    }
    public async Task<JobViewModel> CreateJobAsync(CreateOrUpdateJobViewModel model)
    {
        var entity = await _jobRepository.CreateJobAsync(model.ToEntityJob());
        return entity.Adapt<JobViewModel>();
    }

    public async  Task DeleteJobAsync(long id)
    {
         await _jobRepository.DeleteAsync(id) ;
    }

    public async  Task<JobViewModel> GetJobByIdAsync(long id)
    {
        var entity = await _jobRepository.GetJobByIdAsync(id);
        return entity.Adapt<JobViewModel>();
    }

    public async Task<IEnumerable<JobViewModel>> GetPostsAsync()
    {
        var jobs  = await _jobRepository.GetJobsAsync(p => true);
        return jobs.Select(p => p.ToModelJob());
    }
}