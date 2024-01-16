using NFS.RoomBooking.BusinessLogic.DTO.Room;
using NFS.RoomBooking.BusinessLogic.DTO.UserProfile;


namespace NFS.RoomBooking.BusinessLogic.DTO.Booking;

public class GetBookingDto
{
    public string Id { get; set; } = string.Empty;
    public GetUserProfileDto UserProfile { get; set; }
    public GetRoomDto Room { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}