using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NFS.RoomBooking.BusinessLogic.DTO.User;
using NFS.RoomBooking.BusinessLogic.DTO.UserProfile;
using NFS.RoomBooking.BusinessLogic.Interfaces;

namespace NFS.RoomBooking.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserProfileRepository userProfileRepository, IUserRepository userRepository) : ControllerBase
{

    [HttpGet]
    [Route("GetUserProfile")]
    public IActionResult GetUserProfile(string id) => 
        new JsonResult(userProfileRepository.GetApplicationUserDto(id));

    [HttpGet]
    [Route("GetAllUsersProfile")]
    public IActionResult GetAllUsersProfile() =>
        new JsonResult(userProfileRepository.GetAllApplicationUserDto());

    [HttpPost]
    [Route("CreateUserProfile")]
    public IActionResult CreateUserProfile(CreateUserProfileDto applicationCreateUserProfileDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        IdentityUser? identityUser = await userRepository.CreateUser(createUserDto);

        if (identityUser is null) return BadRequest();

        IdentityResult? identityResult = await userRepository.AssignDefaultRoleToUser(identityUser);
        if (identityResult is { Succeeded: false }) return BadRequest();;
        
        userProfileRepository.CreateUserProfile(new CreateUserProfileDto
        {
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            Gender = createUserDto.Gender,
            UserId = identityUser.Id
        });
        
        return Ok();
    }
}