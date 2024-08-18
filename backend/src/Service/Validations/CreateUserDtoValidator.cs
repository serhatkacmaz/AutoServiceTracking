using AutoServiceTracking.Shared.Dtos.User;
using FluentValidation;

namespace Service.Validations;

public class CreateUserDtoValidator : BaseValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(c => c.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("Invalid email format.");
    }
}
