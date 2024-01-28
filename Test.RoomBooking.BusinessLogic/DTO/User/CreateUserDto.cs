using System.ComponentModel.DataAnnotations;

namespace NFS.RoomBooking.BusinessLogic.DTO.User;

public class CreateUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
}