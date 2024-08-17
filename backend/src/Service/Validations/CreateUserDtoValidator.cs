using Core.Dtos.ServiceEntry;
using FluentValidation;

namespace Service.Validations;

public class CreateUserDtoValidator : AbstractValidator<CreateServiceEntryDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(c => c.LicensePlate)
           .NotEmpty().WithMessage("LicensePlate is required.");

        RuleFor(c => c.BrandName)
           .NotEmpty().WithMessage("BrandName is required.");

        RuleFor(c => c.ModelName)
           .NotEmpty().WithMessage("ModelName is required.");

        RuleFor(c => c.Kilometers)
           .NotNull().WithMessage("Kilometers is required.");

        RuleFor(c => c.ServiceDate)
           .NotNull().WithMessage("ServiceDate is required.");
    }
}
