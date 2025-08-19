using Application.Common.Interfaces;
using Application.Common.Repositories;
using Application.UseCases.Auth.Commands.CreateRefreshToken;
using Domain.Aggregates.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;

namespace Application.UseCases.Auth.Commands.Authenticate
{
    internal class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, CreateRefreshTokenResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticateUserHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, ITokenService tokenService, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateRefreshTokenResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
            {
                throw new AuthenticationException("Invalid email or password");
            }

            var accessToken = _tokenService.GenerateAccessToken(user.Id.ToString(), user.Email, user.Role);
            var refreshTokenValue = _tokenService.GenerateRefreshToken();

            var refreshToken = new RefreshToken(
                user.Id,
                refreshTokenValue,
                DateTime.UtcNow.AddDays(7)
            );

            await _refreshTokenRepository.CreateAsync(refreshToken, cancellationToken);

            return new CreateRefreshTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenValue,
                AccessTokenExpiresAt = _tokenService.GetTokenExpiration()
            };
        }
    }
}
