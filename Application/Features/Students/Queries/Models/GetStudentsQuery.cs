using Application.DTOs.StudentDtos;
using Domain.Abstractions;
using MediatR;

namespace Application.Features.Students.Queries.Models
{
    public record GetStudentsQuery(int page, int pageSize) : IRequest<ResultT<PagedList<StudentDto>>>
    {
    }
}
