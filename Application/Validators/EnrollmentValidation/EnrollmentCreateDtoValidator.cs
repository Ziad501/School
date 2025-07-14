using Application.DTOs.EnrollmentDtos;
using FluentValidation;

namespace Application.Validators.EnrollmentValidation
{
    public class EnrollmentCreateDtoValidator : AbstractValidator<EnrollmentCreateDto>
    {
        public EnrollmentCreateDtoValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("Student ID is required")
                .NotEqual(Guid.Empty).WithMessage("Invalid Student ID");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Course ID is required")
                .NotEqual(Guid.Empty).WithMessage("Invalid Course ID");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid enrollment status");
        }
    }
}
