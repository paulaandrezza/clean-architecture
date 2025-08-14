using Domain.Aggregates.UserAggregate;
using Domain.Enums;

namespace Application.UseCases.Users.Common;

public class UserDto : BaseUserDto
{
    public int Id { get; init; }

    public UserDto(User user) : base(
            user.Name,
            user.Email,
            user.Role,
            user.UserInfo != null ? new UserInfoDto(user.UserInfo) : null)
    {
        Id = user.Id;
    }

    public UserDto(int id, string name, string email, Role role, UserInfoDto? userInfo = null)
            : base(name, email, role, userInfo)
    {
        Id = id;
    }

    public UserDto() : base() { }
}
