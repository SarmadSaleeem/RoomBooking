using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NFS.RoomBooking.BusinessLogic.ApplicationDbContext;
using NFS.RoomBooking.BusinessLogic.DTO.User;
using NFS.RoomBooking.BusinessLogic.Interfaces;
using NFS.RoomBooking.Domain.Classes;
using NFS.RoomBooking.Domain.Constants;

namespace NFS.RoomBooking.BusinessLogic.Repositories;

public class UserRepository(UserManager<ApplicationUser> userManager, AppDbContext appDbContext) : IUserRepository
{
    public async Task<ApplicationUser?> CreateUser(CreateUserDto createUserDto)
    {
        await userManager.CreateAsync(new ApplicationUser()
        {
            Id = Guid.NewGuid().ToString(),
            Email = createUserDto.Email,
            UserName = createUserDto.Email,
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName
        }, createUserDto.Password);
        
        return await userManager.FindByEmailAsync(createUserDto.Email);
    }

    public async Task<IdentityResult?> AssignDefaultRoleToUser(ApplicationUser identityUser) => 
        await userManager.AddToRoleAsync(identityUser, AppRoles.User);
    
    public GetUserProfileDto? GetApplicationUserDtoById(string id) => appDbContext.Users
        .AsNoTracking()
        .Select(user => new GetUserProfileDto()
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender.ToString()
        })
        .FirstOrDefault(user=> user.Id.Equals(id));

    public List<GetUserProfileDto>? GetAllApplicationUserDto() => appDbContext.Users
        .AsNoTracking()
        .Select(user => new GetUserProfileDto()
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender.ToString()
        })
        .ToList();

    public GetUserProfileDto? GetUserProfileDtoByEmail(string email) => appDbContext.Users
        .AsNoTracking()
        .Select(user => new GetUserProfileDto()
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender.ToString()
        })
        .FirstOrDefault(user=> user.Email == email);
}