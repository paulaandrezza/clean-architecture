using Application.UseCases.Users.Common;
using Domain.Enums;

namespace Application.UseCases.Users.Commands.CreateUser;

public class CreateUserDto : BaseUserDto
{
    public string Password { get; init; }
    public string ConfirmPassword { get; init; }
    public CreateUserDto(string name, string email, string password, string confirmPassword,
                           Role role, UserInfoDto? userInfo = null)
            : base(name, email, role, userInfo)
    {
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public CreateUserDto() : base()
    {
    }
}
