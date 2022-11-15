using Classroom.Web.Data;
using Classroom.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Web.Controllers;

public class ClassRoomController:Controller
{
    private readonly ILogger<ClassRoomController> _logger;
    private readonly ApplicationDbContext _context;

    public ClassRoomController(ILogger<ClassRoomController> logger, ApplicationDbContext context)
    {
        _logger = logger ;
        _context = context ;
    }

    public IActionResult Index()
    {
        IEnumerable<Classroom.Web.Data.Classroom> classList = _context.Classrooms!.ToList();
        return View(classList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ClassRoomCreate classRoomCreatemodel)
    {
          var user = new Classroom.Web.Data.Classroom()
          {
             Id = Guid.NewGuid(),
             Name = classRoomCreatemodel.Name,
          };
          if(ModelState.IsValid)
         {
             var result =  _context.Classrooms?.AddAsync(user);

             _context.SaveChanges();

             TempData["success"] = "Category created successfully";

             return RedirectToAction("Index");
         }
         return View(user);
    }

    [HttpGet]
    public IActionResult Delete(Guid? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var clasId = _context.Classrooms?.Find(id);
        if(clasId is null) return NotFound();
        return View(clasId);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(Guid id)
    {
        var obj = _context.Classrooms?.Find(id);

        if(obj == null) return NotFound();
        
        _context.Classrooms?.Remove(obj);
        _context.SaveChanges();
         TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }



}