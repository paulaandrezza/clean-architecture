using Application.Common.Interfaces;
using Application.Common.Repositories;
using Domain.Aggregates.UserAggregate;
using MediatR;
using System.Security.Authentication;

namespace Application.UseCases.Auth.Commands.CreateRefreshToken;

public class CreateRefreshTokenHandler : IRequestHandler<CreateRefreshTokenCommand, CreateRefreshTokenResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenService _tokenService;

    public CreateRefreshTokenHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenService = tokenService;
    }

    public async Task<CreateRefreshTokenResponse> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken, cancellationToken);

        if (refreshToken == null || !refreshToken.IsActive)
        {
            throw new AuthenticationException("Invalid refresh token");
        }

        var user = await _userRepository.GetByIdAsync(refreshToken.UserId, cancellationToken);
        if (user == null)
        {
            throw new AuthenticationException("User not found");
        }

        refreshToken.Revoke("Used for token refresh");
        await _refreshTokenRepository.UpdateAsync(refreshToken, cancellationToken);

        var newAccessToken = _tokenService.GenerateAccessToken(user.Id.ToString(), user.Email, user.Role);
        var newRefreshTokenValue = _tokenService.GenerateRefreshToken();

        var newRefreshToken = new RefreshToken(
            user.Id,
            newRefreshTokenValue,
            DateTime.UtcNow.AddDays(7)
        );

        await _refreshTokenRepository.CreateAsync(newRefreshToken, cancellationToken);

        return new CreateRefreshTokenResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshTokenValue,
            AccessTokenExpiresAt = _tokenService.GetTokenExpiration(),
            TokenType = "Bearer"
        };
    }
}
