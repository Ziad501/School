using Application.DTOs.StudentDtos;
using Application.Features;
using Application.Interfaces;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentService(IStudentRepository _repo) : IStudentService
    {
        public async Task<ResultT<Student>> AddStudentAsync(StudentDto studentDto, CancellationToken cancellation)
        {
            var student = await _repo.GetTableNoTracking().FirstOrDefaultAsync(cancellation);
            _repo.AddAsync(student);
            return student;
        }

        public async Task<ResultT<PagedList<Student>>> GetAllStudents(int page, int pageSize, CancellationToken cancellation)
        {
            return await _repo.GetAllStudents(page, pageSize, cancellation);
        }

        public async Task<ResultT<Student>> GetStudentById(Guid id, CancellationToken cancellation)
        {
            var student = await _repo.GetTableNoTracking()
                .Include(p=>p.Department)
                .FirstOrDefaultAsync(s => s.Id.Equals(id),cancellation);
            return student;
        }
    }
}
