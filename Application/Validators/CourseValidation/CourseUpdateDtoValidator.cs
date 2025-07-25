using Application.DTOs.CourseDto;
using FluentValidation;

namespace Application.Validators.CourseValidation;

public class CourseUpdateDtoValidator : AbstractValidator<CourseUpdateDto>
{
    public CourseUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ID is required")
            .NotEqual(Guid.Empty)
            .WithMessage("Invalid ID format");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Course code is required")
            .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters")
            .Matches("^[A-Z0-9]{3,8}$").WithMessage("Course code must be 3-8 uppercase alphanumeric characters");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Course name is required")
            .MaximumLength(255).WithMessage("Course name cannot exceed 255 characters");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters")
            .When(x => x.Description != null);

        RuleFor(x => x.CreditHours)
            .InclusiveBetween(1, 10).WithMessage("Credit hours must be between 1 and 10");

        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate).WithMessage("Start date must be before end date");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date");

        RuleFor(x => x.Capacity)
            .InclusiveBetween(5, 500).WithMessage("Capacity must be between 5 and 500");

        RuleFor(x => x.TeacherId)
            .Must(id => id == null || id != Guid.Empty).WithMessage("Invalid Teacher ID");
    }
}
