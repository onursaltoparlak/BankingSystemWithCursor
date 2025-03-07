using BankApp.Core.Security.Entities;
using BankApp.Core.Security.Hashing;
using BankApp.Core.Security.JWT;
using BankApp.Domain.Repositories;
using MediatR;

namespace BankApp.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenHelper _tokenHelper;

    public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
    {
        _userRepository = userRepository;
        _tokenHelper = tokenHelper;
    }

    public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.UserForLoginDto.Email);
        if (user == null)
            throw new Exception("User not found");

        if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            throw new Exception("Password is wrong");

        var claims = await _userRepository.GetClaimsAsync(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return accessToken;
    }
} 