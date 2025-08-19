using FluentValidation;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.User.Name).NotEmpty();
            RuleFor(p => p.User.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.User.Password).NotEmpty()
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(p => p.User.ConfirmPassword)
                .NotEmpty()
                .Equal(p => p.User.Password).WithMessage("'Password' and 'ConfirmPassword' must match.");
        }
    }
}
