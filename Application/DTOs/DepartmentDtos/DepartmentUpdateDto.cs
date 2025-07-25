namespace Application.DTOs.DepartmentDtos;

public record DepartmentUpdateDto(
    Guid Id,
    string Name,
    string Code,
    string Description);
