using Microsoft.EntityFrameworkCore;
using NFS.RoomBooking.BusinessLogic.ApplicationDbContext;
using NFS.RoomBooking.BusinessLogic.DTO.Room;
using NFS.RoomBooking.BusinessLogic.Interfaces;
using NFS.RoomBooking.Domain.Classes;

namespace NFS.RoomBooking.BusinessLogic.Repositories;

public class RoomRepository(AppDbContext dbContext) : IRoomRepository
{
    public GetRoomDto? GetById(string id) => dbContext.Rooms
        .AsNoTracking()
        .Select(room => new GetRoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Capacity = room.Capacity,
            Location = room.Location,
            Image = room.PictureUrl
        })
        .FirstOrDefault(room => room.Id == id) ?? null;

    public GetRoomDto? GetByName(string name) => dbContext.Rooms
        .AsNoTracking()
        .Select(room => new GetRoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Capacity = room.Capacity,
            Location = room.Location,
            Image = room.PictureUrl
        })
        .FirstOrDefault(room => room.Name.Equals(name)) ?? null;

    public List<GetRoomDto> GetAll() => dbContext.Rooms
        .AsNoTracking()
        .Select(room => new GetRoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Capacity = room.Capacity,
            Location = room.Location,
            Image = room.PictureUrl
        })
        .ToList();
    
    public async Task Add(CreateRoomDto value)
    {
        await dbContext.Rooms
            .AddAsync(new Room
            {
                Id = Guid.NewGuid().ToString(),
                Name = value.Name,
                Location = value.Location,
                PictureUrl = value.Image,
                Capacity = value.Capacity
            });

        await dbContext.SaveChangesAsync();
    }

    public async Task Update(UpdateRoomDto value)
    {
        await dbContext.Rooms
            .Where(room => room.Id.Equals(value.Id))
            .ExecuteUpdateAsync(calls => calls
                .SetProperty(r => r.Name, value.Name)
                .SetProperty(r => r.Capacity, value.Capacity)
                .SetProperty(r => r.Location, value.Location)
                .SetProperty(r => r.PictureUrl, value.Image)
            );

        await dbContext.SaveChangesAsync();
    }
}