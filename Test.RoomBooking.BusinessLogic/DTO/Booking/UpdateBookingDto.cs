namespace NFS.RoomBooking.BusinessLogic.DTO.Booking;

public class UpdateBookingDto
{
    public string Id { get; set; } = string.Empty;
    public string RoomId { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
}