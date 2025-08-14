using MediatR;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public CreateUserDto User { get; init; }

        public CreateUserCommand(CreateUserDto user)
        {
            User = user;
        }
    }
}
