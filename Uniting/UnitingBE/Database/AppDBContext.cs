using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Entities;
using UnitingBE.Features.Communities;

namespace UnitingBE.Database;

public class AppDBContext: IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<Community> communities { get; set; }
    public DbSet<Post> posts { get; set; }
}