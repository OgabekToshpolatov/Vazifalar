using mvc.Dtos;
using mvc.ViewModel;

namespace mvc.Services;

public interface ICategoryService
{
    Task<List<CategoryView>> GetCategoriesAsync();
    Task<CategoryView> GetCategoryByIdAsync(int categoryId);
    Task AddCategory(CreateCategoryDto categoryDto);
    Task UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto);
    Task DeleteCategory(int categoryId);
}