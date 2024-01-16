using NFS.RoomBooking.BusinessLogic.DTO.Booking;
using NFS.RoomBooking.BusinessLogic.DTO.Room;
namespace NFS.RoomBooking.BusinessLogic.Interfaces;

public interface IRoomRepository
{
    GetRoomDto? GetById(string id);
    GetRoomDto? GetByName(string name);
    List<GetRoomDto>? GetAll();
    Task Add(CreateRoomDto value);
    Task Update(UpdateRoomDto value);
}

// public  interface IBookingRepository
// {
//     GetBookingDto? GetById(string id);
//     GetBookingDto? GetByName(string name);
//     List<GetBookingDto>? GetAll();
//     Task Add(CreateBookingDto value);
//     Task Update(UpdateBookingDto value);
// }

// public interface IRepository<T> where T : class
// {
//     T? GetById(string id);
//     T? GetByName(string name);
//     List<T> GetAll();
//     Task Add(T value);
//     Task Update(T value);
// }