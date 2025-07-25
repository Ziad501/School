using Application.DTOs.StudentCourseDtos;
using FluentValidation;

namespace Application.Validators.StudentCourseValidation;

public sealed class CreateStudentCourseDtoValidator
: AbstractValidator<CreateStudentCourseDto>
{
    public CreateStudentCourseDtoValidator()
    {
        RuleFor(x => x.StudentId)
            .NotEmpty().WithMessage("Student ID is required");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required");

        RuleFor(x => x.Grade)
            .MaximumLength(5).WithMessage("Grade cannot exceed 5 characters")
            .Matches(@"^([A-E][+-]?|F|I|W|P|NP)$")
            .When(x => !string.IsNullOrEmpty(x.Grade))
            .WithMessage("Invalid grade format. Accepts: A-F with +/- modifiers, F, I, W, P, NP");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid enrollment status");
    }
}
