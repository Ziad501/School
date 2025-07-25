using Application.Features;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Interfaces;

public interface IStudentService
{
    Task<ResultT<PagedList<Student>>> GetAllStudents(int page, int pageSize, CancellationToken cancellation);
    Task<ResultT<Student>> GetStudentById(Guid id, CancellationToken cancellation);
    Task<ResultT<Student>> AddStudentAsync(Student student, CancellationToken cancellation);
    Task<Result> UpdateStudentAsync(Student student, CancellationToken cancellation);
    Task<Result> DeleteStudentAsync(Student student, CancellationToken cancellation);
}
