using MediatR;

namespace Application.UseCases.Auth.Commands.CreateRefreshToken;

public class CreateRefreshTokenCommand : IRequest<CreateRefreshTokenResponse>
{
    public string RefreshToken { get; set; } = string.Empty;
}
