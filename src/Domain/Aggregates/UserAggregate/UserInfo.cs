using Domain.Common;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Aggregates.UserAggregate;

[Index(nameof(UserId), IsUnique = true)]
public class UserInfo : BaseEntity, IEntity
{
    public int UserId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public List<Phone> Phones { get; set; }

    public UserInfo(DateTime dateOfBirth, Gender gender, List<Phone> phones)
    {
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Phones = phones;
    }

    public UserInfo() { }
}
