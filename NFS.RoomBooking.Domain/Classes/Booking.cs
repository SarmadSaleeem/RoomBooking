using System.ComponentModel.DataAnnotations.Schema;

namespace NFS.RoomBooking.Domain.Classes;

public class Booking
{
    public string Id { get; set; } = string.Empty;
    public string ApplicationUserId { get; set; } = string.Empty;
    public string RoomId { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    
    //Navigation Property
    public Room Room { get; set; }
    public UserProfile UserProfile { get; set; }
}