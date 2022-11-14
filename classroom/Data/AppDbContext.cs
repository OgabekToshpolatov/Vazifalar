using classroom.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace classroom.Data;

public class AppDbContext : IdentityDbContext<User, UserRole, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<School>? Schools { get; set; }
    public DbSet<Science>? Sciences { get; set; }
    public DbSet<Entities.Task>? Tasks { get; set; }
    public DbSet<UserRoom>? UserRooms { get; set; }
    public DbSet<UserSicence>? UserSciences { get; set; }
    public DbSet<UserTask>? UserTasks { get; set; }
    public DbSet<UserTaskComment>? UserTaskComments { get; set; }



    
}