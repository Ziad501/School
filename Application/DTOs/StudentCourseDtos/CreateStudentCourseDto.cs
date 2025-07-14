using Domain.Entities;

namespace Application.DTOs.StudentCourseDtos
{
    public sealed record CreateStudentCourseDto(
    Guid StudentId,
    Guid CourseId,
    string? Grade = null,
    EnrollmentStatus Status = EnrollmentStatus.Enrolled
    );
}
