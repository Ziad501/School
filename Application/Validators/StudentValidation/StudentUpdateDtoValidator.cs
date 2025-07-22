using Application.DTOs.StudentDtos;
using FluentValidation;

namespace Application.Validators.StudentValidation
{
    public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
    {
        public StudentUpdateDtoValidator()
        {
            RuleFor(x => x.Id).IsValidId();

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

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(500).WithMessage("Address cannot exceed 500 characters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .MaximumLength(50).WithMessage("Phone number cannot exceed 50 characters")
                .Matches(@"^[0-9\s\+\-\(\)]{7,20}$").WithMessage("Invalid phone number format");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Today.AddYears(-16)).WithMessage("Student must be at least 16 years old")
                .GreaterThan(DateTime.Today.AddYears(-100)).WithMessage("Invalid birth date");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("Department ID is required")
                .NotEqual(Guid.Empty).WithMessage("Invalid Department ID");
        }
    }
}
