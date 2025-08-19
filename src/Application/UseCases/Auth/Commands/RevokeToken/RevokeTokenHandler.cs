using Application.Common.Repositories;
using MediatR;

namespace Application.UseCases.Auth.Commands.RevokeToken;

public class RevokeTokenHandler : IRequestHandler<RevokeTokenCommand, bool>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public RevokeTokenHandler(IRefreshTokenRepository refreshTokenRepository)
    {
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<bool> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken, cancellationToken);

        if (refreshToken == null || refreshToken.IsRevoked)
        {
            return false;
        }

        refreshToken.Revoke("Manually revoked");
        await _refreshTokenRepository.UpdateAsync(refreshToken, cancellationToken);

        return true;
    }
}
