using Domain.Entities;

namespace Application.DTOs.StudentCourseDtos
{
    public sealed record UpdateStudentCourseDto(
    Guid Id,
    string? Grade = null,
    EnrollmentStatus? Status = null,
    DateTime? CompletionDate = null
    );
}
