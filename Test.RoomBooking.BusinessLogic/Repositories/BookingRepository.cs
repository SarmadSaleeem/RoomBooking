using Microsoft.EntityFrameworkCore;
using NFS.RoomBooking.BusinessLogic.ApplicationDbContext;
using NFS.RoomBooking.BusinessLogic.DTO.Booking;
using NFS.RoomBooking.BusinessLogic.DTO.Room;
using NFS.RoomBooking.BusinessLogic.DTO.User;
using NFS.RoomBooking.BusinessLogic.Interfaces;
using NFS.RoomBooking.Domain.Classes;

namespace NFS.RoomBooking.BusinessLogic.Repositories;

public class BookingRepository(AppDbContext dbContext) : IBookingRepository
{
    public GetBookingDto? GetById(string id) => dbContext.Bookings
        .AsNoTracking()
        .Include(x=> x.ApplicationUser)
        .Select(booking => new GetBookingDto
        {
            Id = booking.Id,
            UserProfile = new GetUserProfileDto
            {
                Id = booking.ApplicationUser.ToString(),
                FirstName = booking.ApplicationUser.FirstName,
                LastName = booking.ApplicationUser.LastName,
                PhoneNumber = booking.ApplicationUser.PhoneNumber,
                Email = booking.ApplicationUser.Email,
                Gender = booking.ApplicationUser.Gender.ToString()
            },
            Room = new GetRoomDto
            {
                Id = booking.Room.Id,
                Name = booking.Room.Name,
                Capacity = booking.Room.Capacity,
                Image = booking.Room.PictureUrl,
                Location = booking.Room.Location
            },
            StartTime= booking.StartTime.ToString(),
            EndTime = booking.EndTime.ToString()
        })
        .FirstOrDefault(booking => booking.Id.Equals(id));

    public List<GetBookingDto?> GetByUserName(string name) => dbContext.Bookings
        .AsNoTracking()
        .Include(x => x.ApplicationUser)
        .Include(x => x.Room)
        .Where(user=> user.ApplicationUser.FirstName.ToLower().Equals(name.ToLower()))
        .Select(booking => new GetBookingDto()
        {
            Id = booking.Id,
            UserProfile = new GetUserProfileDto()
            {
                Id = booking.ApplicationUser.Id,
                FirstName = booking.ApplicationUser.FirstName,
                LastName = booking.ApplicationUser.LastName,
                Gender = booking.ApplicationUser.Gender.ToString(),
                Email = booking.ApplicationUser.Email,
                PhoneNumber = booking.ApplicationUser.PhoneNumber
            },
            Room = new GetRoomDto()
            {
                Id = booking.Room.Id,
                Name = booking.Room.Name,
                Capacity = booking.Room.Capacity,
                Location = booking.Room.Location,
                Image = booking.Room.PictureUrl.ToString()
            },

            StartTime = booking.StartTime.ToString(),
            EndTime = booking.EndTime.ToString(),
            
        }).ToList();

    public List<GetBookingDto> GetAll() => dbContext.Bookings
        .Include(x=> x.ApplicationUser)
        .Select(booking => new GetBookingDto
        {
            Id = booking.Id,
            UserProfile = new GetUserProfileDto
            {
                Id = booking.ApplicationUser.Id,
                FirstName = booking.ApplicationUser.FirstName,
                LastName = booking.ApplicationUser.LastName,
                PhoneNumber = booking.ApplicationUser.PhoneNumber,
                Email = booking.ApplicationUser.Email,
                Gender = booking.ApplicationUser.Gender.ToString()
            },
            Room = new GetRoomDto
            {
                Id = booking.Room.Id,
                Name = booking.Room.Name,
                Capacity = booking.Room.Capacity,
                Image = booking.Room.PictureUrl,
                Location = booking.Room.Location
            },
            StartTime= booking.StartTime.ToString(),
            EndTime = booking.EndTime.ToString()
        })
        .ToList();

    public async Task Add(CreateBookingDto value)
    {
        await dbContext.Bookings.AddAsync(new Booking
        {
            Id = Guid.NewGuid().ToString(),
            ApplicationUserId = value.ApplicationUserId,
            StartTime = Convert.ToDateTime(value.StartTime),
            EndTime = Convert.ToDateTime(value.EndTime),
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
                .SetProperty(b => b.StartTime, Convert.ToDateTime(value.StartTime))
                .SetProperty(b => b.EndTime, Convert.ToDateTime(value.EndTime)));

        await dbContext.SaveChangesAsync();

    }
}