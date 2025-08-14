using FluentValidation;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.User.Name).NotEmpty();
            RuleFor(p => p.User.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.User.Password).NotEmpty();
            RuleFor(p => p.User.ConfirmPassword).NotEmpty();
            RuleFor(p => p.User.Password).Equal(p => p.User.ConfirmPassword).WithMessage("'Password' and 'ConfirmPassword' must match.");
        }
    }
}
