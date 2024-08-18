using AutoServiceTracking.Shared.Dtos.ServiceEntry;
using FluentValidation;

namespace Service.Validations;

public class CreateServiceEntryValidator : BaseValidator<CreateServiceEntryDto>
{
    public CreateServiceEntryValidator()
    {
        RuleFor(c => c.LicensePlate)
            .NotEmpty().WithMessage("LicensePlate is required.")
            .Matches(@"^\d{2}[A-Z]{1,3}\d{2,4}$").WithMessage("LicensePlate must follow the format: '00XXX0000' (e.g., '34ABC1234').");


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
