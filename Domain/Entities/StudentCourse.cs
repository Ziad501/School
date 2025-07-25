namespace Domain.Entities;

public class StudentCourse : BaseEntity
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    public DateTime? CompletionDate { get; set; }
    public string Grade { get; set; } = string.Empty;
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Enrolled;
    public virtual Student Student { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;

}
