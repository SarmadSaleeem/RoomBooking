namespace NFS.RoomBooking.Domain.Classes;

public class Booking
{
    public string Id { get; set; } = string.Empty;
    public string ApplicationUserId { get; set; } = string.Empty;
    public string RoomId { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    //Navigation Property
    public Room Room { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}