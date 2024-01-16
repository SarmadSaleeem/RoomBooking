namespace NFS.RoomBooking.BusinessLogic.DTO.Room;

public class CreateRoomDto
{
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
}