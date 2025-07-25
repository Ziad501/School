using Application.Features;
using Application.Interfaces;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentService(IStudentRepository _repo) : IStudentService
    {
        public async Task<ResultT<Student>> AddStudentAsync(Student student, CancellationToken cancellation)
        {
            if (student is null)
                return Errors.NullValue;
            _repo.AddAsync(student, cancellation);
            return student;
        }

        public async Task<Result> DeleteStudentAsync(Student student, CancellationToken cancellation)
        {
            await _repo.DeleteAsync(student, cancellation);
            return Result.Success();
        }

        public async Task<ResultT<PagedList<Student>>> GetAllStudents(int page, int pageSize, CancellationToken cancellation)
        {
            return await _repo.GetAllStudents(page, pageSize, cancellation);
        }

        public async Task<ResultT<Student>> GetStudentById(Guid id, CancellationToken cancellation)
        {
            var student = await _repo.GetAsync(
                            filter: p => p.Id == id,
                            include: x => x.Include(p => p.Department),
                            cancellationToken: cancellation);
            if (student is null)
            {
                return Errors.NotFound;
            }
            return student;
        }

        public async Task<Result> UpdateStudentAsync(Student student, CancellationToken cancellation)
        {
            await _repo.UpdateAsync(student);
            return Result.Success();
        }
    }
}
