using Classroom.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Web.Controllers;

public class TasksController:Controller
{
    private readonly ApplicationDbContext _context;

    public TasksController(ApplicationDbContext context)
    {
        _context = context ;
    }
}