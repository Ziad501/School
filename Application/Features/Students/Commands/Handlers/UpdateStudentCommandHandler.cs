using Application.DTOs.StudentDtos;
using Application.Features.Students.Commands.Models;
using Application.Interfaces;
using Domain.Abstractions;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Features.Students.Commands.Handlers
{
    public class UpdateStudentCommandHandler(IStudentService _service, IMapper _mapper, IValidator<StudentUpdateDto> _validator) : IRequestHandler<UpdateStudentCommand, Result>
    {
        public async Task<Result> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request.dto, cancellationToken);
            if (!result.IsValid)
                return new Error("Validation failed", string.Join(", ", result.Errors.Select(e => e.ErrorMessage)));

            if (request.dto is null)
                return Errors.NullValue;

            var studentDb = await _service.GetStudentById(request.dto.Id, cancellationToken);

            if (studentDb.IsFailure)
                return studentDb.Error;

            _mapper.Map(request.dto, studentDb.Value);
            await _service.UpdateStudentAsync(studentDb.Value, cancellationToken);
            return Result.Success();
        }
    }
}
