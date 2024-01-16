namespace NFS.RoomBooking.BusinessLogic.DTO.Booking;

public class CreateBookingDto
{
    public string ApplicationUserId { get; set; } = string.Empty;
    public string RoomId { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}