using Domain.Enums;

namespace Application.UseCases.Users.Common;

public class BaseUserDto
{
    public string Name { get; init; }
    public string Email { get; init; }
    public Role Role { get; init; }
    public UserInfoDto? UserInfo { get; init; }

    public BaseUserDto(string name, string email, Role role, UserInfoDto? userInfo = null)
    {
        Name = name;
        Email = email;
        Role = role;
        UserInfo = userInfo;
    }

    public BaseUserDto() { }
}
