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
    public DbSet<Comment> comments { get; set; }
    public DbSet<Bookmarks> bookmarks { get; set; }
    public DbSet<CommunitiesFollowed> communitiesFolloweds { get; set; }
    public DbSet<Favorites> favorites { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Community>()
            .HasOne(x=>x.user)
            .WithMany(x=>x.communities)
            .HasForeignKey(x=>x.AppUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Post>()
            .HasOne(x=>x.user)
            .WithMany(x=>x.posts)
            .HasForeignKey(x=>x.AppUserId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.Entity<Comment>()
            .HasOne(x=>x.user)
            .WithMany(x=>x.comments)
            .HasForeignKey(x=>x.AppUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Bookmarks>()
            .HasOne(x=>x.user)
            .WithMany(x=>x.bookmarks)
            .HasForeignKey(x=>x.AppUserId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.Entity<CommunitiesFollowed>()
           .HasOne(x => x.User)
           .WithMany(x => x.communitiesFollowed)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Favorites>()
            .HasOne(x => x.user)
            .WithMany(x => x.favorites)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.NoAction);


        base.OnModelCreating(builder);
    }
}