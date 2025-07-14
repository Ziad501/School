namespace Application.DTOs.StudentDtos
{
    public record StudentUpdateDto(
        Guid Id,
        string FirstName, 
        string LastName, 
        string Email, 
        string Address,
        string Phone, 
        DateTime DateOfBirth, 
        Guid DepartmentId);
}
