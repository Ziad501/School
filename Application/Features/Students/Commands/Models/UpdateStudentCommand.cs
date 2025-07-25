using Application.DTOs.StudentDtos;
using Domain.Abstractions;
using MediatR;

namespace Application.Features.Students.Commands.Models
{
    public record UpdateStudentCommand(StudentUpdateDto dto) : IRequest<Result>;
}
