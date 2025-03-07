using BankApp.Application.Features.Auth.Commands.Login;
using BankApp.Application.Features.Auth.Commands.Register;
using BankApp.Core.Security.DTOs;
using BankApp.Core.Security.Entities;
using BankApp.Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AccessToken>> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        var result = await _mediator.Send(new LoginCommand { UserForLoginDto = userForLoginDto });
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<AccessToken>> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        var result = await _mediator.Send(new RegisterCommand { UserForRegisterDto = userForRegisterDto });
        return Ok(result);
    }
} 