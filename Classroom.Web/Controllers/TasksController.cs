using Classroom.Web.Data;
using Classroom.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Web.Controllers;

public class TasksController:Controller
{
    private readonly ApplicationDbContext _context;

    public TasksController(ApplicationDbContext context)
    {
        _context = context ;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddTask()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddTask(CreateTaskDto taskDto)
    {
        if(!ModelState.IsValid)
        {
            return View(taskDto);
        }
             
        var task =new  Classroom.Web.Data.Task
        {
             Title = taskDto.Title,
             Description = taskDto.Description
        };
        var classRoom = _context.Classrooms?.FirstOrDefault(c => c.Id == taskDto.ClassroomId);
        if(classRoom is null) return NotFound("Berilgan classroom id bo`yicha classroom topilmadi.");
        
        classRoom.Tasks?.Add(task);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));

    }
}