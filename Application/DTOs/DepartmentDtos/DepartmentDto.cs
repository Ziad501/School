namespace Application.DTOs.DepartmentDtos
{
    public record DepartmentResponseDto(
        Guid Id, 
        string Name, 
        string Code, 
        Guid? HeadOfDepartmentId, 
        string? HeadOfDepartmentName);

}
