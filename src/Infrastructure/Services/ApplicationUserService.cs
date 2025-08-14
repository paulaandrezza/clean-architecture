using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    internal class ApplicationUserService : IApplicationUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public bool IsAuthenticated => (_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated).GetValueOrDefault();

        public string UserId => _httpContextAccessor.HttpContext?.User.FindFirst("UserId")?.Value ?? string.Empty;

        public string Locale => _httpContextAccessor.HttpContext?.User.FindFirst("Locale")?.Value ?? string.Empty;

        public IEnumerable<Claim> Claims => _httpContextAccessor.HttpContext?.User.Claims ?? Array.Empty<Claim>();

        public ApplicationUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
