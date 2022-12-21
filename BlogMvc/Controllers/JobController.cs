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

    public IActionResult Create() => View();

    [HttpPost]
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
    
    public async Task<IActionResult> GetJobs()
    {
        var jobs = await _jobService.GetPostsAsync();
        return View(jobs.ToList());
    }

    public async Task<IActionResult> Branding()
    {
        var jobs = await _jobService.GetPostsAsync();
        var brandingJobs = jobs.Where(p => p.CategoryId == 3).ToList();
        return View(brandingJobs);
    }

    public async Task<IActionResult> Web()
    {
        var jobs = await _jobService.GetPostsAsync();
        var brandingJobs = jobs.Where(p => p.CategoryId == 2).ToList();
        return View(brandingJobs);
    }

    public async Task<IActionResult> Illustration()
    {
        var jobs = await _jobService.GetPostsAsync();
        var brandingJobs = jobs.Where(p => p.CategoryId == 1).ToList();
        return View(brandingJobs);
    }
}