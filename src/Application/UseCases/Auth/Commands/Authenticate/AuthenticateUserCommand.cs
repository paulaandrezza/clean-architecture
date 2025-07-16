using MediatR;

namespace Application.UseCases.Auth.Commands.Authenticate
{
    public class AuthenticateUserCommand : IRequest<AuthenticateUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
