using BlogMvc.Data;
using BlogMvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogMvc.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ILogger<CategoryRepository> _logger;
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context,ILogger<CategoryRepository> logger)
    {
        _logger = logger ;
        _context = context ;
    }
    public  async Task<Category> CreateAsync(Category category)
    {
        var entity = await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Categories.FindAsync(id);
        if(entity is null) return;
        _context.Categories.Remove(entity);
        _context.SaveChanges();
    }

    public async Task<Category> GetCategoryAsync(long id) => 
                                await _context.Categories.FirstOrDefaultAsync( p => p.Id == id);
    
}