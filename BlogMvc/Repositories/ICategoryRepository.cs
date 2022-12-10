using BlogMvc.Entities;

namespace BlogMvc.Repositories;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category post);
    Task<Category> GetPostAsync(long id);
    Task DeleteAsync(long id);
}