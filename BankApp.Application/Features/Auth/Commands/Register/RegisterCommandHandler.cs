using BankApp.Core.Security.Entities;
using BankApp.Core.Security.Hashing;
using BankApp.Core.Security.JWT;
using BankApp.Domain.Repositories;
using MediatR;

namespace BankApp.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AccessToken>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenHelper _tokenHelper;

    public RegisterCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
    {
        _userRepository = userRepository;
        _tokenHelper = tokenHelper;
    }

    public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.UserForRegisterDto.Email);
        if (existingUser != null)
            throw new Exception("User already exists");

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

        var user = new User
        {
            Email = request.UserForRegisterDto.Email,
            FirstName = request.UserForRegisterDto.FirstName,
            LastName = request.UserForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        await _userRepository.AddAsync(user);
        var claims = await _userRepository.GetClaimsAsync(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return accessToken;
    }
} 