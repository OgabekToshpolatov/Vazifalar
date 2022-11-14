using classroom.Data;
using classroom.Models;
using Microsoft.AspNetCore.Mvc;

namespace classroom.Controllers;

public class SchoolController:Controller
{
    private readonly ILogger<SchoolController> _logger;
    private readonly AppDbContext _context;

    public SchoolController(ILogger<SchoolController> logger , AppDbContext context)
    {
       _logger = logger ;
       _context = context ;
    }

    [HttpGet]
    public IActionResult SchoolCreate()
    {
        return View();
    }
}