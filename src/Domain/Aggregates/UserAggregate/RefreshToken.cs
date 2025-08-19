using Domain.Common;

namespace Domain.Aggregates.UserAggregate;

public class RefreshToken : BaseEntity, IEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? RevokedReason { get; set; }

    public RefreshToken(int userId, string token, DateTime expiresAt)
    {
        UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        IsRevoked = false;
        CreatedAt = DateTime.UtcNow;
    }

    public RefreshToken() { }

    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    public bool IsActive => !IsRevoked && !IsExpired;

    public void Revoke(string reason = null)
    {
        IsRevoked = true;
        RevokedReason = reason;
    }
}
