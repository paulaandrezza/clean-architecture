using Application.Common.Interfaces;
using Application.Common.Repositories;
using Application.UseCases.Users.Commands.CreateUser;
using Domain.Aggregates.UserAggregate;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.UseCases.Users.Commands.CreateGymUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<CreateUserCommand> _validator;
        private readonly IPasswordHasher _bcryptPasswordHasher;

        public CreateUserHandler(IUserRepository userRepository, IValidator<CreateUserCommand> validator, IPasswordHasher bcryptPasswordHasher)
        {
            _userRepository = userRepository;
            _validator = validator;
            _bcryptPasswordHasher = bcryptPasswordHasher;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string hashedPassword = _bcryptPasswordHasher.HashPassword(request.Password);
            var user = new User
                (
                    request.Name,
                    request.Email,
                    hashedPassword,
                    Role.Company,
                    request.UserInfo,
                    DateTime.Now
                );

            await _userRepository.AddAsync(user, cancellationToken);
            return new CreateUserResponse(user.Id);
        }
    }
}
