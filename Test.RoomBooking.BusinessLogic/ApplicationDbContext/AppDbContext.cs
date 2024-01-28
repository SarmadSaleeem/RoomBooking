using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NFS.RoomBooking.Domain.Classes;
using NFS.RoomBooking.Domain.Constants;

namespace NFS.RoomBooking.BusinessLogic.ApplicationDbContext;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var admin = new ApplicationUser()
        {
            Id = "db2053d7-9294-4f22-ab94-2fe2c4514261",
            FirstName = "Super",
            LastName = "Admin",
            Email = "admin@gmail.com",
            EmailConfirmed = true,
            UserName = "admin@gmail.com",
            NormalizedUserName = "ADMIN@GMAIL.COM"
        };

        var passwordHasher = new PasswordHasher<ApplicationUser>();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin@123");
        
        // Change the table names for Identity entities
        builder.Entity<ApplicationUser>().ToTable("Users").HasData(admin);
        builder.Entity<IdentityRole>()
            .ToTable("Roles")
            .HasData(new List<IdentityRole>
            {
                new() { Id = "d0e76862-5de0-4ac4-864c-9af18b7071ab", Name = AppRoles.Administrator, NormalizedName = AppRoles.Administrator},
                new() { Id = "2f55d065-c3cf-46d6-a705-6bb50a36d8fc", Name = AppRoles.User, NormalizedName = AppRoles.User },
                new() { Id = "99992fd3-b266-450a-ac72-a0b581c13a1e", Name = AppRoles.Reception, NormalizedName = AppRoles.Reception }
            });
        
        var adminRole = new IdentityUserRole<string>()
        {

            RoleId = "d0e76862-5de0-4ac4-864c-9af18b7071ab",
            UserId = "db2053d7-9294-4f22-ab94-2fe2c4514261"
        };
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles").HasData(adminRole);
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
    }
    
    
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }
}