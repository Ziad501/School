namespace Domain.Entities
{
    public class Department
    {

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<DepartmentCourse> DepartmentCourses { get; set; } = new HashSet<DepartmentCourse>();
    }
}
