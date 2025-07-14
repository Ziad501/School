namespace Application.DTOs.StudentDtos
{
    public record StudentDto(
        Guid Id, 
        string FirstName, 
        string LastName, 
        string Email,
        string Address, 
        string Phone, 
        DateTime DateOfBirth, 
        DateTime EnrollmentDate,
        Guid DepartmentId, 
        string DepartmentName);
}
