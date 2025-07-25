using Domain.Entities;

namespace Application.DTOs.EnrollmentDtos;

public record EnrollmentUpdateDto(
    Guid StudentId,
    Guid CourseId,
    EnrollmentStatus Status,
    string? Grade = null);
