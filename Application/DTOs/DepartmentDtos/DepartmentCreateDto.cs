namespace Application.DTOs.DepartmentDtos
{
    public record DepartmentCreateDto(
        string Name, 
        string Code,
        string Description);
}
