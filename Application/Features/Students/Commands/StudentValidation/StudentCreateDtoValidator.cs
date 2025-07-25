using Application.DTOs.StudentDtos;
using Application.Interfaces;
using Application.Interfaces.Generic;
using Application.Validators;
using Domain.Entities;
using FluentValidation;

namespace Application.Features.Students.Commands.StudentValidation
{
    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        private readonly IStudentRepository _studentRepository;
        public StudentCreateDtoValidator(IStudentRepository studentRepository, IGenericRepository<Department> department)
        {
            _studentRepository = studentRepository;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(255).WithMessage("Email cannot exceed 255 characters")
                .MustAsync(BeUniqueMail).WithMessage("Email already exists");

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
                .NotEqual(Guid.Empty).WithMessage("Invalid Department ID")
                .DepartmentMustExist(department);
        }
        private async Task<bool> BeUniqueMail(string Email, CancellationToken cancellationToken)
        {
            var exists = await _studentRepository.GetAsync(p => p.Email.Equals(Email), cancellationToken: cancellationToken);
            return exists == null;
        }
    }
}
