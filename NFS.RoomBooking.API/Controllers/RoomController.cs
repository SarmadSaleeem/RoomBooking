
using Microsoft.AspNetCore.Mvc;
using NFS.RoomBooking.BusinessLogic.DTO.Room;
using NFS.RoomBooking.BusinessLogic.Interfaces;

namespace NFS.RoomBooking.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoomController(IRoomRepository roomRepository) : ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll() => new JsonResult(roomRepository.GetAll());

    [HttpGet]
    [Route("GetById")]
    public IActionResult GetRoomById(string id) => new JsonResult(roomRepository.GetById(id));
    
    [HttpPost]
    [Route("Add")]
    public async Task Add(CreateRoomDto room) => await roomRepository.Add(room);

    [HttpPost]
    [Route("Update")]
    public async Task Update(UpdateRoomDto room) => await roomRepository.Update(room);
}