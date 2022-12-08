using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Dtos;
using mvc.Entities;
using mvc.ViewModel;

namespace mvc.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context ;
    }
    public async Task AddCategory(CreateCategoryDto categoryDto)
    {
        var category = new Category()
        {  
            Name = categoryDto.Name,
            ParentId = categoryDto.ParentId
        };

        await _context.Categories!.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategory(int categoryId)
    {
         var category =await  _context.Categories.FindAsync(categoryId);
         if(category is null) return;
          _context.Categories.Remove(category);
          await _context.SaveChangesAsync();         

    }

    public async Task<List<CategoryView>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.Where(c => c.ParentId == null).ToListAsync();

        var categorieViewsList = new List<CategoryView>();

        foreach (var category in categories)
        {
            var categoryView = ToCategoryView(category);

            categorieViewsList.Add(categoryView);
        }

        return categorieViewsList;
        
    }
    private CategoryView ToCategoryView(Category category)
    {
        var categoryView = new CategoryView()
        {
            Id = category.Id,
            Name = category.Name,
        };

        if (category.Children is null)
            return categoryView;

        foreach (var child in category.Children)
        {
            categoryView.Children ??= new List<CategoryView>();
            categoryView.Children.Add(ToCategoryView(child));
        }

        return categoryView;
    }

    public async Task<CategoryView> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _context.Categories?.FirstOrDefaultAsync(category => category.Id == categoryId);

        return ToCategoryView(category);
    }

    public async Task UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
    {
        var category = await _context?.Categories?.FirstOrDefaultAsync(category => category.Id == categoryId);

        if (category is null) return ;

        category.Name = updateCategoryDto.Name;
        category.ParentId = updateCategoryDto.ParentId;

        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
}