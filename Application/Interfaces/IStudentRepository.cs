using Application.Features;
using Application.Interfaces.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Task<PagedList<Student>> GetAllStudents(int page, int pageSize,CancellationToken cancellation);
    }
}
