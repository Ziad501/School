using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Application.Implmentation
{
    public class StudentService(IStudentRepository _repo) : IStudentService
    {
        public async Task<List<Student>> GetAllStudents(CancellationToken cancellation)
        {
            return await _repo.GetAllStudents(cancellation);
        }

        public async Task<Student> GetStudentById(Guid id, CancellationToken cancellation)
        {
            var student = await _repo.GetTableNoTracking()
                .Include(p=>p.Department)
                .FirstOrDefaultAsync(s => s.Id.Equals(id),cancellation);
            return student;
        }
    }
}
