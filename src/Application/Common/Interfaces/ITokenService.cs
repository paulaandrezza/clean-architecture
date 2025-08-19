using Domain.Enums;
using System.Security.Claims;

namespace Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(string userId, string email, Role role);
        string GenerateRefreshToken();
        ClaimsPrincipal? ValidateToken(string token);
        DateTime GetTokenExpiration();
    }
}
