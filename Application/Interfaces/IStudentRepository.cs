using Application.Interfaces.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Task<List<Student>> GetAllStudents(CancellationToken cancellation);
    }
}
