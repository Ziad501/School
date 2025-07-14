using Application.DTOs.TeatcherDto;
using FluentValidation;

namespace Application.Validators.TeatcherValidation
{
    public class TeacherCreateDtoValidator : AbstractValidator<TeacherCreateDto>
    {
        public TeacherCreateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(255).WithMessage("Email cannot exceed 255 characters");

            RuleFor(x => x.Phone)
                .MaximumLength(50).WithMessage("Phone number cannot exceed 50 characters")
                .Matches(@"^[0-9\s\+\-\(\)]{7,20}$").WithMessage("Invalid phone number format")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("Department ID is required")
                .NotEqual(Guid.Empty).WithMessage("Invalid Department ID");
        }
    }
}
