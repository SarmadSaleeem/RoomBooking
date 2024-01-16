using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NFS.RoomBooking.BusinessLogic.DTO.Booking;

namespace NFS.RoomBooking.BusinessLogic.Interfaces;

public  interface IBookingRepository
{
    GetBookingDto? GetById(string id);
    GetBookingDto? GetByName(string name);
    List<GetBookingDto>? GetAll();
    Task Add(CreateBookingDto value);
    Task Update(UpdateBookingDto value);
}