using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Entities;

namespace mvc.Data;

public class AppDbContext:IdentityDbContext<AppUser, AppUserRole, Guid>
{
    public DbSet<Organization>? Organizations { get; set; }
    public DbSet<OrganizationUser>? OrganizationUsers { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Job>? Jobs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<OrganizationUser>().HasKey(user => new { user.UserId, user.OrganizationId });
    }

}