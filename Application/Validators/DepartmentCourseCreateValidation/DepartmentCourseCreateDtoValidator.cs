using Application.DTOs.DepartmentCourseDtos;
using FluentValidation;

namespace Application.Validators.DepartmentCourseCreateValidation
{
    public class DepartmentCourseCreateDtoValidator : AbstractValidator<DepartmentCourseCreateDto>
    {
        public DepartmentCourseCreateDtoValidator()
        {
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("Department ID is required")
                .NotEqual(Guid.Empty).WithMessage("Invalid Department ID");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Course ID is required")
                .NotEqual(Guid.Empty).WithMessage("Invalid Course ID");
        }
    }
}
