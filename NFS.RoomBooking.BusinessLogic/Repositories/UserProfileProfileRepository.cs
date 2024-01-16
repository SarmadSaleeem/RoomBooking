using Microsoft.EntityFrameworkCore;
using NFS.RoomBooking.BusinessLogic.ApplicationDbContext;
using NFS.RoomBooking.BusinessLogic.DTO.UserProfile;
using NFS.RoomBooking.BusinessLogic.Interfaces;
using NFS.RoomBooking.Domain.Classes;
using NFS.RoomBooking.Domain.Enums;

namespace NFS.RoomBooking.BusinessLogic.Repositories;

public class UserProfileProfileRepository(AppDbContext appDbContext) : IUserProfileRepository
{
    public GetUserProfileDto? GetApplicationUserDto(string id) => appDbContext.UserProfiles
        .AsNoTracking()
        .Include(x => x.User)
        .Select(user => new GetUserProfileDto()
        {
            Id = user.Id,
            Email = user.User.Email,
            PhoneNumber = user.User.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender.ToString()
        })
        .FirstOrDefault(user=> user.Id.Equals(id));

    public List<GetUserProfileDto>? GetAllApplicationUserDto() => appDbContext.UserProfiles
        .AsNoTracking()
        .Include(x=> x.User)
        .Select(user => new GetUserProfileDto()
        {
            Id = user.Id,
            Email = user.User.Email,
            PhoneNumber = user.User.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender.ToString()
        })
        .ToList();

    public void CreateUserProfile(CreateUserProfileDto createUserProfileDto)
    {
        Enum.TryParse(createUserProfileDto.Gender, out Gender gender);
        
        appDbContext.UserProfiles
            .Add(new UserProfile
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = createUserProfileDto.FirstName,
                LastName = createUserProfileDto.LastName,
                Gender = gender,
                UserId = createUserProfileDto.UserId
            });

        appDbContext.SaveChanges();
    }
}