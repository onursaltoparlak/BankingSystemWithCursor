using BankApp.Core.Security.DTOs;
using BankApp.Core.Security.Entities;
using BankApp.Core.Security.JWT;
using MediatR;

namespace BankApp.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<AccessToken>
{
    public required UserForRegisterDto UserForRegisterDto { get; set; }

    public RegisterCommand()
    {
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto)
    {
        UserForRegisterDto = userForRegisterDto;
    }
} 