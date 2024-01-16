using NFS.RoomBooking.BusinessLogic.DTO.UserProfile;

namespace NFS.RoomBooking.BusinessLogic.Interfaces;

public interface IUserProfileRepository
{
    GetUserProfileDto? GetApplicationUserDto(string id);
    List<GetUserProfileDto>? GetAllApplicationUserDto();
    void CreateUserProfile(CreateUserProfileDto createUserProfileDto);
}