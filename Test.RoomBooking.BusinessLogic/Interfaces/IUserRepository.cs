using Microsoft.AspNetCore.Identity;
using NFS.RoomBooking.BusinessLogic.DTO.User;
using NFS.RoomBooking.Domain.Classes;

namespace NFS.RoomBooking.BusinessLogic.Interfaces;

public interface IUserRepository
{
    Task<ApplicationUser?> CreateUser(CreateUserDto createUserDto);
    Task<IdentityResult?> AssignDefaultRoleToUser(ApplicationUser identityUser);
    GetUserProfileDto? GetApplicationUserDtoById(string id);
    List<GetUserProfileDto>? GetAllApplicationUserDto();
    GetUserProfileDto? GetUserProfileDtoByEmail(string email);
}