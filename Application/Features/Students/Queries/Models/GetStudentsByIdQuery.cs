using Application.DTOs.StudentDtos;
using Domain.Abstractions;
using MediatR;

namespace Application.Features.Students.Queries.Models
{
    public record GetStudentsByIdQuery(Guid Id) : IRequest<ResultT<StudentDto>>;
}
