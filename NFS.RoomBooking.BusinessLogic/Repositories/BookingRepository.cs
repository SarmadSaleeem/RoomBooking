using Microsoft.EntityFrameworkCore;
using NFS.RoomBooking.BusinessLogic.ApplicationDbContext;
using NFS.RoomBooking.BusinessLogic.DTO.Booking;
using NFS.RoomBooking.BusinessLogic.DTO.Room;
using NFS.RoomBooking.BusinessLogic.DTO.UserProfile;
using NFS.RoomBooking.BusinessLogic.Interfaces;
using NFS.RoomBooking.Domain.Classes;

namespace NFS.RoomBooking.BusinessLogic.Repositories;

public class BookingRepository(AppDbContext dbContext) : IBookingRepository
{
    public GetBookingDto? GetById(string id) => dbContext.Bookings
        .AsNoTracking()
        .Include(x=> x.UserProfile.User)
        .Select(booking => new GetBookingDto
        {
            Id = booking.Id,
            UserProfile = new GetUserProfileDto
            {
                Id = booking.UserProfile.Id,
                FirstName = booking.UserProfile.FirstName,
                LastName = booking.UserProfile.LastName,
                PhoneNumber = booking.UserProfile.User.PhoneNumber,
                Email = booking.UserProfile.User.Email,
                Gender = booking.UserProfile.Gender.ToString()
            },
            Room = new GetRoomDto
            {
                Id = booking.Room.Id,
                Name = booking.Room.Name,
                Capacity = booking.Room.Capacity,
                Image = booking.Room.PictureUrl,
                Location = booking.Room.Location
            },
            Time = booking.Time,
            Date = booking.Date
        })
        .FirstOrDefault(booking => booking.Id.Equals(id));

    public GetBookingDto GetByName(string name) => throw new NotImplementedException();

    public List<GetBookingDto> GetAll() => dbContext.Bookings
        .Include(x=> x.UserProfile.User)
        .Select(booking => new GetBookingDto
        {
            Id = booking.Id,
            UserProfile = new GetUserProfileDto
            {
                Id = booking.UserProfile.Id,
                FirstName = booking.UserProfile.FirstName,
                LastName = booking.UserProfile.LastName,
                PhoneNumber = booking.UserProfile.User.PhoneNumber,
                Email = booking.UserProfile.User.Email,
                Gender = booking.UserProfile.Gender.ToString()
            },
            Room = new GetRoomDto
            {
                Id = booking.Room.Id,
                Name = booking.Room.Name,
                Capacity = booking.Room.Capacity,
                Image = booking.Room.PictureUrl,
                Location = booking.Room.Location
            },
            Time = booking.Time,
            Date = booking.Date
        })
        .ToList();

    public async Task Add(CreateBookingDto value)
    {
        await dbContext.Bookings.AddAsync(new Booking
        {
            Id = Guid.NewGuid().ToString(),
            ApplicationUserId = value.ApplicationUserId,
            Date = value.Date,
            Time = value.Time,
            RoomId = value.RoomId
        });
        await dbContext.SaveChangesAsync();

    }

    public async Task Update(UpdateBookingDto value)
    {
        await dbContext.Bookings
            .Where(booking => booking.Id.Equals(value.Id))
            .ExecuteUpdateAsync(cells => cells
                .SetProperty(b => b.RoomId, value.RoomId)
                .SetProperty(b => b.Date, value.Date)
                .SetProperty(b => b.Time, value.Time));

        await dbContext.SaveChangesAsync();

    }
}