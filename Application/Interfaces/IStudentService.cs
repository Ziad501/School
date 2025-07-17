using Application.DTOs.StudentDtos;
using Application.Features;
using Domain.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        public Task<ResultT<PagedList<Student>>> GetAllStudents(int page, int pageSize, CancellationToken cancellation);
        public Task<ResultT<Student>> GetStudentById(Guid id, CancellationToken cancellation);
        public Task<ResultT<Student>> AddStudentAsync(StudentDto studentDto, CancellationToken cancellation);

    }
}
