namespace Application.UseCases.Auth.Commands.CreateRefreshToken;

public class CreateRefreshTokenResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime AccessTokenExpiresAt { get; set; }
    public string TokenType { get; set; } = "Bearer";
}