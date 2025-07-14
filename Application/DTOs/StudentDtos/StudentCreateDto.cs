namespace Application.DTOs.StudentDtos
{
    public record StudentCreateDto(
        string FirstName, 
        string LastName, 
        string Email, 
        string Address,
        string Phone, 
        DateTime DateOfBirth, 
        Guid DepartmentId);
}
