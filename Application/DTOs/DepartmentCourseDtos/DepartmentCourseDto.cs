namespace Application.DTOs.DepartmentCourseDtos
{
    public record DepartmentCourseResponseDto(
        Guid Id, 
        Guid DepartmentId, 
        string DepartmentName,
        Guid CourseId, 
        string CourseName, 
        bool IsCoreRequirement);
}
