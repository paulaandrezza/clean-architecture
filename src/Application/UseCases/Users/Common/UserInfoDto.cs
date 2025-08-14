using Domain.Aggregates.UserAggregate;
using Domain.Enums;

namespace Application.UseCases.Users.Common;

public class UserInfoDto
{
    public DateTime DateOfBirth { get; init; }
    public Gender Gender { get; init; }
    public List<PhoneDto> Phones { get; init; } = new();

    public UserInfoDto(UserInfo userInfo)
    {
        DateOfBirth = userInfo.DateOfBirth;
        Gender = userInfo.Gender;
        Phones = userInfo.Phones?.Select(p => new PhoneDto(p.PhoneNumber, p.IsWhatsApp)).ToList() ?? new();
    }

    public UserInfoDto(DateTime dateOfBirth, Gender gender, List<PhoneDto>? phones = null)
    {
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Phones = phones ?? new();
    }

    public UserInfoDto() { }
}
