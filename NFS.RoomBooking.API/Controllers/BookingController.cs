using Microsoft.AspNetCore.Mvc;
using NFS.RoomBooking.BusinessLogic.DTO.Booking;
using NFS.RoomBooking.BusinessLogic.Interfaces;

namespace NFS.RoomBooking.API.Controllers;

public class BookingController(IBookingRepository bookingRepository) : ControllerBase
{

    [HttpGet]
    [Route("GetBookingById")]
    public IActionResult GetBookingById(string id) => new JsonResult(bookingRepository.GetById(id));

    [HttpGet]
    [Route("GetAllBookings")]
    public IActionResult GetAllBookings() => new JsonResult(bookingRepository.GetAll());

    [HttpPost]
    [Route("AddBooking")]
    public Task AddBooking(CreateBookingDto newBooking) => bookingRepository.Add(newBooking);

    [HttpPost]
    [Route("UpdateBooking")]
    public Task UpdateBooking(UpdateBookingDto booking) => bookingRepository.Update(booking);
}