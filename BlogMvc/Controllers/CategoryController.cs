using BlogMvc.Models.Category;
using BlogMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogMvc.Controllers;

public class CategoryController:Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;

    public CategoryController(ILogger<CategoryController> logger , ICategoryService categoryService)
    {
        _logger = logger ;
        _categoryService = categoryService ;
    }  

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrUpdateViewModelCategory model)
    {
        if(!ModelState.IsValid) return View();
        var category = await _categoryService.CreateCategorytAsync(model);
        return LocalRedirect("/Category/Index");
    }

    public IActionResult Index() => View();


}