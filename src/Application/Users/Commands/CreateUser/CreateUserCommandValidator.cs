using FluentValidation;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.DisplayName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.UserRole).NotEmpty();
            RuleFor(x => x.OfficeId).NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty()
                .Equal(x => x.ConfirmPassword).WithMessage("Password and confirmation password do not match.");

            RuleFor(x => x.DoB)
            .GreaterThanOrEqualTo(x => new System.DateTime(1900, 1, 1))
            .WithMessage("Invalid date");

            RuleFor(x => x.DateofJoining)
            .GreaterThanOrEqualTo(x => new System.DateTime(1900, 1, 1))
            .WithMessage("Invalid date");
        }
    }
}
