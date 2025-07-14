namespace Application.DTOs.TeatcherDto
{
    public record TeacherUpdateDto(
        Guid Id, 
        string FirstName, 
        string LastName, 
        string Email, 
        string? Phone, 
        Guid DepartmentId);
}
