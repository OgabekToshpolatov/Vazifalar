using BlogMvc.Data;
using BlogMvc.Entities;

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
    public  Task<Category> CreateAsync(Category post)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetPostAsync(long id)
    {
        throw new NotImplementedException();
    }
}