using BlogMvc.Data;
using BlogMvc.Entities;
using BlogMvc.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BlogMvc.Controllers;

public class ContactController:Controller
{
    private readonly AppDbContext _context;

    public ContactController(AppDbContext context)
    {
        _context = context ;
    }
    
    public  IActionResult Index() => View();

    public  IActionResult SendMessage() => View();

    public  IActionResult ViewMessage() => View();

    [HttpPost]
    public async Task<IActionResult> SendMessage(SendMessageViewModel model)
    {
        if(!ModelState.IsValid) return View();
        
        var entity = model.Adapt<Contact>();
         
         await _context.Contacts.AddAsync(entity);
         await  _context.SaveChangesAsync();
        return LocalRedirect($"/contact/viewmessage");
    }
}