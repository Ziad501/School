namespace Domain.Entities
{
    public class DepartmentCourse
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
