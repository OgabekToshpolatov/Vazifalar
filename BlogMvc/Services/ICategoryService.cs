using BlogMvc.Models.Category;

namespace BlogMvc.Services;

public interface ICategoryService
{
    Task DeleteCategoryAsync(long id);
    Task<CategoryViewModel> GetCategoryAsync(long id);
    Task<CategoryViewModel> CreateCategorytAsync(CreateOrUpdateViewModelCategory model);
}