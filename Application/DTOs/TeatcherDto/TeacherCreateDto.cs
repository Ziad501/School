namespace Application.DTOs.TeatcherDto
{
    public record TeacherCreateDto(
        string FirstName, 
        string LastName, 
        string Email, 
        string? Phone, 
        Guid DepartmentId);
}
