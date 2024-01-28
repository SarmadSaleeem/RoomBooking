using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFS.RoomBooking.BusinessLogic.DTO.Booking;
using NFS.RoomBooking.BusinessLogic.Interfaces;
using NFS.RoomBooking.Domain.Constants;

namespace NFS.RoomBooking.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookingController(IBookingRepository bookingRepository) : ControllerBase
{
    [Authorize(Roles = $"{AppRoles.Administrator},{AppRoles.Reception}")]
    [HttpGet]
    [Route("GetBookingById")]
    public IActionResult GetBookingById(string id) => new JsonResult(bookingRepository.GetById(id));

    
    // [Authorize(Roles = $"{AppRoles.Administrator},{AppRoles.Reception}")]
    [HttpGet]
    [Route("GetAllBookings")]
    public IActionResult GetAllBookings() => new JsonResult(bookingRepository.GetAll());

    // [Authorize(Roles = $"{AppRoles.Administrator},{AppRoles.Reception},{AppRoles.User}")]
    [AllowAnonymous]
    [HttpPost]
    [Route("AddBooking")]
    public async Task<IActionResult> AddBooking(CreateBookingDto newBooking)
    {
        var result = await bookingRepository.Add(newBooking);
        if (result)
            return Ok();

        return BadRequest();
    }

    [Authorize(Roles = $"{AppRoles.Administrator},{AppRoles.Reception},{AppRoles.User}")]
    [HttpPost]
    [Route("UpdateBooking")]
    public Task UpdateBooking(UpdateBookingDto booking) => bookingRepository.Update(booking);

    [AllowAnonymous]
    [HttpGet]
    [Route("GetBookingsByUserName")]
    public IActionResult GetBookingsByUserName(string userName) => new JsonResult(bookingRepository.GetBookingsByUserName(userName));
}