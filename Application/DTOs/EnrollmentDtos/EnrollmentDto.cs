using Domain.Entities;

namespace Application.DTOs.EnrollmentDtos;

public record EnrollmentResponseDto(
    Guid Id,
    Guid StudentId,
    string StudentName,
    Guid CourseId,
    string CourseName,
    DateTime EnrollmentDate,
    DateTime? CompletionDate,
    EnrollmentStatus Status,
    string? Grade);
