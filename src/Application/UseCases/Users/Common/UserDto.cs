using Domain.Aggregates.UserAggregate;
using Domain.Enums;

namespace Application.UseCases.Users.Common
{
    public class UserDto
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role UserProfileType { get; set; }
        public UserInfo? UserInfo { get; set; }

        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            UserProfileType = user.Role;
            UserInfo = user.UserInfo;
        }
    }
}
