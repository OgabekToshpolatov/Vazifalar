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
    public async Task<JobViewModel> CreateCategorytAsync(CreateOrUpdateJobViewModel model)
    {
        var entity = await _jobRepository.CreateAsync(model.ToEntityJob());
        return entity.Adapt<JobViewModel>();
    }

    public async  Task DeleteCategoryAsync(long id)
    {
         await _jobRepository.DeleteAsync(id) ;
    }

    public async  Task<JobViewModel> GetCategoryAsync(long id)
    {
        var entity = await _jobRepository.GetCategoryAsync(id);
        return entity.Adapt<JobViewModel>();
    }
}