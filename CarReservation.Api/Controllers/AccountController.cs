using CarReservation.Application.DTOs;
using CarReservation.Application.Interfaces.Services;
using CarReservation.Application.Wrappers;
using CarReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CarReservation.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[SwaggerTag("Create, read, update and delete User")]
public class AccountController : ControllerBase
{
    #region Fields

    private readonly IUserService userService;

    #endregion Fields

    #region CTOR

    public AccountController(IUserService userService)
    {
        this.userService = userService;
    }

    #endregion CTOR

    [HttpPost]
    [ProducesResponseType(typeof(Response<User>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<Response<User>> Login([FromQuery]string email, [FromQuery] string password)
    {
        return await userService.GetUser(email, password);
    }


    [HttpPost]
    [ProducesResponseType(typeof(Response<UserDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [Produces("application/json")]

    public async Task<Response<UserDTO>> Register([FromBody] UserDTO userDTO)
    {
        return await userService.AddUser(userDTO);
    }
}

