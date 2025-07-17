using Application.DTOs.StudentDtos;
using Domain.Abstractions;
using MediatR;

namespace Application.Features.Students.Commands.Models
{
    public record AddStudentCommand(StudentCreateDto dto) : IRequest<ResultT<StudentDto>>;
}
