using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFS.RoomBooking.BusinessLogic.DTO.User;
using NFS.RoomBooking.BusinessLogic.Interfaces;
using NFS.RoomBooking.Domain.Classes;
using NFS.RoomBooking.Domain.Constants;

namespace NFS.RoomBooking.API.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IUserRepository userRepository) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [Route("GetUserProfile")]
    public IActionResult GetUserProfile(string id) => 
        new JsonResult(userRepository.GetApplicationUserDto(id));

    [Authorize(Roles = AppRoles.Administrator)]
    [HttpGet]
    [Route("GetAllUsersProfile")]
    public IActionResult GetAllUsersProfile() =>
        new JsonResult(userRepository.GetAllApplicationUserDto());
    
    [AllowAnonymous]
    [HttpPost]
    [Route("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        ApplicationUser? identityUser = await userRepository.CreateUser(createUserDto);

        if (identityUser is null) return BadRequest();
        await userRepository.AssignDefaultRoleToUser(identityUser);
        return Ok();
    }
}