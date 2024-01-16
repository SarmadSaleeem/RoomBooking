namespace NFS.RoomBooking.Domain.Classes;

public class Room
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string Location { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
}