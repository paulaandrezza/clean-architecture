using Domain.Enums;

namespace Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string userEmail, Role userProfileType);
    }
}
