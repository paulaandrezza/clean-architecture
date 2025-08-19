using Application.UseCases.Auth.Commands.CreateRefreshToken;
using MediatR;

namespace Application.UseCases.Auth.Commands.Authenticate
{
    public class AuthenticateUserCommand : IRequest<CreateRefreshTokenResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
