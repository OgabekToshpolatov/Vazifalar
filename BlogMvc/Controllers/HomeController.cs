using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogMvc.Models;
using BlogMvc.Services;
using Microsoft.AspNetCore.Authorization;

namespace BlogMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IJobsService _jobService;

    public HomeController(ILogger<HomeController> logger, IJobsService jobService)
    {
        _logger = logger;
        _jobService = jobService ;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}
