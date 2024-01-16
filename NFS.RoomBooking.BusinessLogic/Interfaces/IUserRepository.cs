using Microsoft.AspNetCore.Identity;
using NFS.RoomBooking.BusinessLogic.DTO.User;

namespace NFS.RoomBooking.BusinessLogic.Interfaces;

public interface IUserRepository
{
    Task<IdentityUser?> CreateUser(CreateUserDto createUserDto);
}