using Domain.Entities;

namespace Application.DTOs.StudentCourseDtos
{
    public sealed record StudentCourseDto(
    Guid Id,
    DateTime EnrollmentDate,
    DateTime? CompletionDate,
    string? Grade,
    EnrollmentStatus Status,
    Guid StudentId,
    Guid CourseId
    );
}
