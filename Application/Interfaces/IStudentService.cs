using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudents(CancellationToken cancellation);
        public Task<Student> GetStudentById(Guid id, CancellationToken cancellation);

    }
}
