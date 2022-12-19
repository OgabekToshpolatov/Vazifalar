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

    public async Task<IActionResult> SendMessage(SendMessageViewModel model)
    {
         if(!ModelState.IsValid)
                      return View();
         
         var Message = model.Adapt<Contact>();
        return View();
    } 
}