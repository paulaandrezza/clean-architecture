using Application.UseCases.Users.Commands.CreateUser;
using Domain.Aggregates.UserAggregate;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.Users.Commands.CreateGymUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
