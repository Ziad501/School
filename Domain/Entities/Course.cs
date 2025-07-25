namespace Domain.Entities;

public class Course : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CreditHours { get; set; } = 3;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Capacity { get; set; } = 30;
    public DateTime Period { get; set; }
    public Guid? TeacherId { get; set; }
    public virtual Teacher? Teacher { get; set; }
    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    public virtual ICollection<DepartmentCourse> DepartmentCourses { get; set; } = new HashSet<DepartmentCourse>();
}
