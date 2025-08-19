using Application.Common.Mappings.Users;
using Application.Common.Repositories;
using Domain.Aggregates.UserAggregate;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreateUserHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.User.Email, cancellationToken);

            if (existingUser != null)
                throw new ConflictException($"The email '{request.User.Email}' is already in use.");

            string hashedPassword = _passwordHasher.HashPassword(null, request.User.Password);
            var user = new User
            (
                request.User.Name,
                request.User.Email,
                hashedPassword,
                request.User.Role,
                request.User.UserInfo.MapToUserInfo(),
                DateTime.UtcNow
            );

            await _userRepository.AddAsync(user, cancellationToken);
            return new CreateUserResponse(user.Id);
        }
    }
}
