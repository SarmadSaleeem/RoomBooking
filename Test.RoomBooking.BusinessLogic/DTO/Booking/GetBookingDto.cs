using NFS.RoomBooking.BusinessLogic.DTO.Room;
using NFS.RoomBooking.BusinessLogic.DTO.User;


namespace NFS.RoomBooking.BusinessLogic.DTO.Booking;

public class GetBookingDto
{
    public string Id { get; set; } = string.Empty;
    public GetUserProfileDto UserProfile { get; set; }
    public GetRoomDto Room { get; set; }
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
}