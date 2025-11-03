using Backend.DTOs;
using FluentValidation;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required")
            .MaximumLength(100);

        RuleFor(x => x.Phone)
            .Matches(@"^[0-9]{10}$")
            .When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage("Phone number must be 10 digits");

        RuleFor(x => x.Role)
            .IsInEnum();

        RuleFor(x => x.ExternalId)
            .MaximumLength(50);
    }
}
