using System.Security.Claims;

namespace Application.Common.Interfaces
{
    public interface IApplicationUserService
    {
        bool IsAuthenticated { get; }
        string UserId { get; }
        string Locale { get; }
        IEnumerable<Claim> Claims { get; }
    }
}
