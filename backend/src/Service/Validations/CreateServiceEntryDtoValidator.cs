using AutoServiceTracking.Shared.Dtos.User;
using FluentValidation;

namespace Service.Validations;

public class CreateServiceEntryDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateServiceEntryDtoValidator()
    {
        RuleFor(c => c.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("Invalid email format.");
    }
}
