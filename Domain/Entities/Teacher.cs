namespace Domain.Entities;

public class Teacher : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime HireDate { get; set; } = DateTime.UtcNow;
    public Guid DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
    public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
}
