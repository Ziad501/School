namespace Domain.Entities;

public class Department : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid? HeadOfDepartmentId { get; set; }
    public virtual ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public ICollection<DepartmentCourse> DepartmentCourses { get; set; } = new HashSet<DepartmentCourse>();
}
