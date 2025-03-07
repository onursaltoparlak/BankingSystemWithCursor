using BankApp.Core.Security.DTOs;
using BankApp.Core.Security.Entities;
using BankApp.Core.Security.JWT;
using MediatR;

namespace BankApp.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<AccessToken>
{
    public required UserForLoginDto UserForLoginDto { get; set; }

    public LoginCommand()
    {
    }

    public LoginCommand(UserForLoginDto userForLoginDto)
    {
        UserForLoginDto = userForLoginDto;
    }
} 