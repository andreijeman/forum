using Forum.Application.DTOs;
using Forum.Application.Feature.User.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto user)
    {
        var command = new RegisterUserCommand
        {
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
        };
        
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}