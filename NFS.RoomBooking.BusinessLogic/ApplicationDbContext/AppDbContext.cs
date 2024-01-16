using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NFS.RoomBooking.Domain.Classes;
using NFS.RoomBooking.Domain.Constants;

namespace NFS.RoomBooking.BusinessLogic.ApplicationDbContext;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Change the table names for Identity entities
        builder.Entity<IdentityUser>().ToTable("Users");
        builder.Entity<IdentityRole>()
            .ToTable("Roles")
            .HasData(new List<IdentityRole>
            {
                new() { Id = "d0e76862-5de0-4ac4-864c-9af18b7071ab", Name = AppRoles.Administrator, NormalizedName = AppRoles.Administrator},
                new() { Id = "2f55d065-c3cf-46d6-a705-6bb50a36d8fc", Name = AppRoles.User, NormalizedName = AppRoles.User },
                new() { Id = "99992fd3-b266-450a-ac72-a0b581c13a1e", Name = AppRoles.Reception, NormalizedName = AppRoles.Reception }
            });
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
    }
    
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    
    
}