using Application.Features.Students.Commands.Models;
using Application.Interfaces;
using Domain.Abstractions;
using MediatR;

namespace Application.Features.Students.Commands.Handlers;

public class DeleteStudentCommandHandler(IStudentService _service) : IRequestHandler<DeleteStudentCommand, Result>
{
    public async Task<Result> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _service.GetStudentById(request.Id, cancellationToken);
        if (student.Value == null) return Errors.NotFound;
        await _service.DeleteStudentAsync(student.Value, cancellationToken);
        return Result.Success();
    }
}




