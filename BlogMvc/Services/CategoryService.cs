using BlogMvc.Entities;
using BlogMvc.Models.Category;
using BlogMvc.Repositories;
using Mapster;

namespace BlogMvc.Services;

public class CategoryService : ICategoryService
{
    private readonly ILogger<CategoryService> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ILogger<CategoryService> logger , ICategoryRepository categoryRepository)
    {
        _logger = logger ;
        _categoryRepository = categoryRepository ;
    }
    public  async Task<CategoryViewModel> CreateCategorytAsync(CreateOrUpdateViewModelCategory model)
    {       
          var entity = await _categoryRepository.CreateAsync(model.Adapt<Category>());
          return entity.Adapt<CategoryViewModel>();
    }

    public async Task DeleteCategoryAsync(long id)
    {
       await _categoryRepository.DeleteAsync(id);
    }

    public async  Task<CategoryViewModel> GetCategoryAsync(long id)
    {
        var entity = await _categoryRepository.GetCategoryAsync(id);
        return entity.Adapt<CategoryViewModel>();
    }
}