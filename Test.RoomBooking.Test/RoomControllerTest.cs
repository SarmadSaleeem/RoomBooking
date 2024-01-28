using Microsoft.AspNetCore.Mvc;
using Moq;
using NFS.RoomBooking.API.Controllers;
using NFS.RoomBooking.BusinessLogic.DTO.Room;
using NFS.RoomBooking.BusinessLogic.Interfaces;

namespace NFS.RoomBooking.Test;

public class RoomControllerTest
{
    [Fact]
    public void GetAll_ReturnsJsonResult()
    {
        // Arrange
        var mockRoomRepository = new Mock<IRoomRepository>();
        
        var controller = new RoomController(mockRoomRepository.Object);

        // Act
        var result = controller.GetAll();

        // Assert
        Assert.IsType<JsonResult>(result);
    }

    [Fact]
    public void GetAll_CallsRoomRepositoryGetAll()
    {
        // Arrange
        var mockRoomRepository = new Mock<IRoomRepository>();
        var controller = new RoomController(mockRoomRepository.Object);

        // Act
        controller.GetAll();

        // Assert
        mockRoomRepository.Verify(r => r.GetAll(), Times.Once);
    }

    [Fact]
    public void GetRoomById()
    {
        var mockRoomRepository = new Mock<IRoomRepository>();
        var controller = new RoomController(mockRoomRepository.Object);

        var j = controller.GetRoomById("1");
        
        mockRoomRepository.Verify(x => x.GetById("1"));
    }

    [Fact]
    public void GetRoomById_where_id_isnull()
    {
        var mockRoomRepository = new Mock<IRoomRepository>().Object;
        var controller = new RoomController(mockRoomRepository);

        GetRoomDto getRoomDto = mockRoomRepository.GetById("1");

        Assert.NotNull(getRoomDto);
    }
}