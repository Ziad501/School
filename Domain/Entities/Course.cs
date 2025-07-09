namespace Domain.Entities
{
    public class Course
    {
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<DepartmentCourse> DepartmentCourses { get; set; } = new HashSet<DepartmentCourse>();
    }
}
