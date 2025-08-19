using MediatR;

namespace Application.UseCases.Auth.Commands.RevokeToken;

public class RevokeTokenCommand : IRequest<bool>
{
    public string RefreshToken { get; set; } = string.Empty;
}
