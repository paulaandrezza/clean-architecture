using Application.UseCases.Users.Common;
using Domain.Aggregates.UserAggregate;

namespace Application.Common.Mappings.Users;

public static class UserMapper
{
    public static UserDto MapToUserDto(this User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        return new UserDto(user.Id, user.Name, user.Email, user.Role, MapToUserInfoDto(user.UserInfo));

    }
    public static UserInfo? MapToUserInfo(this UserInfoDto dto)
    {
        if (dto == null)
            return null;

        return new UserInfo
        (
            dto.DateOfBirth,
            dto.Gender,
            dto.Phones?.Select(MapToPhone).ToList() ?? new List<Phone>()
        );
    }

    public static UserInfoDto? MapToUserInfoDto(this UserInfo? userInfo)
    {
        if (userInfo == null)
            return null;

        return new UserInfoDto
        (
            userInfo.DateOfBirth,
            userInfo.Gender,
            userInfo.Phones?.Select(MapToPhoneDto).ToList() ?? new List<PhoneDto>()
        );
    }

    public static Phone MapToPhone(this PhoneDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new Phone
        (
            dto.PhoneNumber,
            dto.IsWhatsApp
        );
    }

    public static PhoneDto MapToPhoneDto(this Phone phone)
    {
        if (phone == null)
            throw new ArgumentNullException(nameof(phone));

        return new PhoneDto
        (
            phone.PhoneNumber,
            phone.IsWhatsApp
        );

    }
}
