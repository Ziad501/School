using Domain.Entities;

namespace Application.DTOs.EnrollmentDtos;

public record EnrollmentCreateDto(
    Guid StudentId,
    Guid CourseId,
    EnrollmentStatus Status = EnrollmentStatus.Enrolled);
