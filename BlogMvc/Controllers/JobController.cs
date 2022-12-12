using BlogMvc.Models.Job;
using BlogMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogMvc.Controllers;

public class JobController:Controller
{
    private readonly ILogger<JobController> _logger;
    private readonly IJobsService _jobService;

    public JobController(IJobsService jobService, ILogger<JobController> logger)
    {
        _logger = logger ;
        _jobService = jobService ;
    }

    public async Task<IActionResult> Create(CreateOrUpdateJobViewModel model)
    {
        if(!ModelState.IsValid) return View();
        var job = await _jobService.CreateJobAsync(model);
        return LocalRedirect($"/job/article/{job.Id}");

    }
    public async Task<IActionResult> Article([FromRoute]long id)
    {
        var post = await _jobService.GetJobByIdAsync(id);
        return View(post);
    }
}