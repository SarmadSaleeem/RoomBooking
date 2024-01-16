using Microsoft.AspNetCore.Identity;
using NFS.RoomBooking.BusinessLogic.DTO.User;
using NFS.RoomBooking.BusinessLogic.Interfaces;

namespace NFS.RoomBooking.BusinessLogic.Repositories;

public class UserRepository(UserManager<IdentityUser> userManager) : IUserRepository
{
    public async Task<IdentityUser?> CreateUser(CreateUserDto createUserDto)
    {
        await userManager.CreateAsync(new IdentityUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = createUserDto.Email,
            PhoneNumber = createUserDto.PhoneNumber,
            UserName = createUserDto.Email
        }, createUserDto.Password);
        
        return await userManager.FindByEmailAsync(createUserDto.Email);
    }
}