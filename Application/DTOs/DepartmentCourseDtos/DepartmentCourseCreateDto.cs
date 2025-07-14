namespace Application.DTOs.DepartmentCourseDtos
{
    public record DepartmentCourseCreateDto(
        Guid DepartmentId, 
        Guid CourseId, 
        bool IsCoreRequirement = true);
}
