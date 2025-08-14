using Domain.Common;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Domain.Aggregates.UserAggregate;

[Index(nameof(Email), IsUnique = true)]
public class User : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public UserInfo? UserInfo { get; set; }
    public DateTime CreatedAt { get; set; }

    public User(string name, string email, string password, Role role, UserInfo? userInfo, DateTime createdAt)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        UserInfo = userInfo;
        CreatedAt = createdAt;
    }

    public User(int id, string name, string email, string password, Role role, UserInfo? userInfo, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        UserInfo = userInfo;
        CreatedAt = createdAt;
    }

    public User() { }
}
