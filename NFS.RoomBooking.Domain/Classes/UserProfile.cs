using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NFS.RoomBooking.Domain.Enums;

namespace NFS.RoomBooking.Domain.Classes;

public class UserProfile
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }

    //Navigation Property
    public IdentityUser User { get; set; }
}