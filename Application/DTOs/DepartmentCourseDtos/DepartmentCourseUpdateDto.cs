namespace Application.DTOs.DepartmentCourseDtos
{
    public record DepartmentCourseUpdateDto(
        Guid DepartmentId, 
        Guid CourseId, 
        bool IsCoreRequirement);
}
