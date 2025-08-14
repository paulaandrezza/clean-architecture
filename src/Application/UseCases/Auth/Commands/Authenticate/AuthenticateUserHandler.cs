using Application.Common.Interfaces;
using Application.Common.Repositories;
using FluentValidation;
using MediatR;
using System.Security.Authentication;

namespace Application.UseCases.Auth.Commands.Authenticate
{
    internal class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IValidator<AuthenticateUserCommand> _validator;
        private readonly IPasswordHasher _bcryptPasswordHasher;

        public AuthenticateUserHandler(IUserRepository userRepository, ITokenService tokenService, IValidator<AuthenticateUserCommand> validator, IPasswordHasher bcryptPasswordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _validator = validator;
            _bcryptPasswordHasher = bcryptPasswordHasher;
        }

        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
            if (user == null || !_bcryptPasswordHasher.VerifyPassword(user.Password, request.Password))
            {
                throw new AuthenticationException();
            }

            var token = _tokenService.GenerateToken(user.Id.ToString(), user.Email, user.Role);
            return new AuthenticateUserResponse { Token = token };
        }
    }
}
