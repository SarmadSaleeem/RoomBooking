using Microsoft.AspNetCore.Identity;
using NFS.RoomBooking.Domain.Enums;

namespace NFS.RoomBooking.Domain.Classes;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
}