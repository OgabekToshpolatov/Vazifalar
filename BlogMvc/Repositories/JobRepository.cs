using BlogMvc.Data;
using BlogMvc.Entities;

namespace BlogMvc.Repositories;

public class JobRepository : IJobRepository
{
    private readonly AppDbContext _context;

    public JobRepository(AppDbContext context)
    {
        _context = context ;
    }
    public async Task<Job> CreateJobAsync(Job post)
    {
        var entity = await _context.Jobs.AddAsync(post);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Jobs.FindAsync(id);
        _context.Jobs.Remove(entity);
        await _context.SaveChangesAsync();

    }

    public async Task<Job> GetJobByIdAsync(long id) => await _context.Jobs.FindAsync(id);
}