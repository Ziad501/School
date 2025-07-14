namespace Application.DTOs.CourseDto
{
    public record CourseCreateDto(
        string Code, 
        string Name, 
        string? Description, 
        int CreditHours,
        DateTime StartDate, 
        DateTime EndDate, 
        int Capacity, 
        Guid? TeacherId = null);
}
