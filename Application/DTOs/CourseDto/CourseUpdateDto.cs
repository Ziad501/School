namespace Application.DTOs.CourseDto;

public record CourseUpdateDto(
    Guid Id,
    string Code,
    string Name,
    string? Description,
    int CreditHours,
    DateTime StartDate,
    DateTime EndDate,
    int Capacity,
    Guid? TeacherId = null);
