namespace Domain.Entities;

public class DepartmentCourse : BaseEntity
{
    public Guid DepartmentId { get; set; }
    public Guid CourseId { get; set; }
    public bool IsCoreRequirement { get; set; } = true;
    public virtual Department Department { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
}
