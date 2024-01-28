using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NFS.RoomBooking.BusinessLogic.DTO.User;
using NFS.RoomBooking.BusinessLogic.Interfaces;
using NFS.RoomBooking.Domain.Classes;
using NFS.RoomBooking.Domain.Constants;

namespace NFS.RoomBooking.API.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class UserController(IUserRepository userRepository, UserManager<ApplicationUser> userManager) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [Route("GetUserProfileById")]
    public IActionResult GetUserProfile(string id) => 
        new JsonResult(userRepository.GetApplicationUserDtoById(id));

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
    
    [HttpGet]
    [Route("GetUserProfileByEmail")]
    public IActionResult GetUserProfileByEmail(string email) =>
        new JsonResult(userRepository.GetUserProfileDtoByEmail(email));

    [HttpGet]
    [Route("GetUserRole")]
    public async Task<IActionResult> GetUserRole(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null) return NotFound("User not found");

        var userRole = await userManager.GetRolesAsync(user);

        return new JsonResult(userRole);
    }
}