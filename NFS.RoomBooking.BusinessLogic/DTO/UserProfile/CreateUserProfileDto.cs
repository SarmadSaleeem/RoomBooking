using System.ComponentModel.DataAnnotations;

namespace NFS.RoomBooking.BusinessLogic.DTO.UserProfile;

public class CreateUserProfileDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    public string Gender { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
}
