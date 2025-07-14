using Application.DTOs.StudentCourseDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.StudentCourseValidation
{
    public sealed class UpdateStudentCourseDtoValidator
    : AbstractValidator<UpdateStudentCourseDto>
    {
        public UpdateStudentCourseDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("ID is required")
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid ID format");
            RuleFor(x => x.Grade)
                .MaximumLength(5).WithMessage("Grade cannot exceed 5 characters")
                .Matches(@"^([A-E][+-]?|F|I|W|P|NP)$")
                .When(x => !string.IsNullOrEmpty(x.Grade))
                .WithMessage("Invalid grade format. Accepts: A-F with +/- modifiers, F, I, W, P, NP");

            RuleFor(x => x.Status)
                .IsInEnum()
                .When(x => x.Status.HasValue)
                .WithMessage("Invalid enrollment status");

            RuleFor(x => x.CompletionDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
                .When(x => x.CompletionDate.HasValue)
                .WithMessage("Completion date cannot be in the past")
                .Must(date => date > DateTime.UtcNow.AddYears(-10))
                .When(x => x.CompletionDate.HasValue)
                .WithMessage("Completion date is unrealistic");
        }
    }
}
