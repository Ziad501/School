namespace Domain.Entities
{
    public class Student
    {
        public int DeptartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
