namespace Application.DTOs.TeatcherDto
{
    public record TeacherResponseDto(
        Guid Id, 
        string FirstName, 
        string LastName, 
        string Email, 
        string? Phone,
        Guid DepartmentId, 
        string DepartmentName);
}
