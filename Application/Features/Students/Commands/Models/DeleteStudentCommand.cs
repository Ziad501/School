using Domain.Abstractions;
using MediatR;

namespace Application.Features.Students.Commands.Models;

public record DeleteStudentCommand(Guid Id) : IRequest<Result>;





