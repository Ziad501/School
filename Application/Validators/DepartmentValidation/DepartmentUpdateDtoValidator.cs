using Application.DTOs.DepartmentDtos;
using FluentValidation;

namespace Application.Validators.DepartmentValidation;

public class DepartmentUpdateDtoValidator : AbstractValidator<DepartmentUpdateDto>
{
    public DepartmentUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("ID is required")
             .NotEqual(Guid.Empty)
             .WithMessage("Invalid ID format");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required")
            .MaximumLength(10)
            .WithMessage("Code cannot exceed 10 characters");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(255)
            .WithMessage("Name cannot exceed 255 characters");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Description cannot exceed 1000 characters");
    }
}