using NFS.RoomBooking.BusinessLogic.DTO.Booking;

namespace NFS.RoomBooking.BusinessLogic.Interfaces;

public  interface IBookingRepository
{
    GetBookingDto? GetById(string id);
    List<GetBookingDto?> GetByUserName(string name);
    List<GetBookingDto>? GetAll();
    Task Add(CreateBookingDto value);
    Task Update(UpdateBookingDto value);
}