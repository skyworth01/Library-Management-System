using Backend.DTOs;
using FluentValidation;

public class CreateUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.EmailId)
            .NotEmpty().WithMessage("Email id is required")
            .EmailAddress().WithMessage("Invalid email address");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one number");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required")
            .MaximumLength(100);

        RuleFor(x => x.Phone)
            .Matches(@"^[0-9]{10}$")
            .When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage("Phone number must be 10 digits");
    }
}
