using Application.DTOs.StudentDtos;
using Application.Features.Students.Commands.Models;
using Application.Interfaces;
using Domain.Abstractions;
using Domain.Entities;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Features.Students.Commands.Handlers
{
    public class AddStudentCommandHandler(IStudentRepository _repo, IMapper _mapper, IValidator<StudentCreateDto> _validator) :
        IRequestHandler<AddStudentCommand, ResultT<StudentDto>>
    {
        public async Task<ResultT<StudentDto>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request.dto, cancellationToken);
            if (!result.IsValid)
                return new Error("Validation failed", string.Join(", ", result.Errors.Select(e => e.ErrorMessage)));

            if (request.dto is null)
                return Errors.NullValue;
            var Student = _mapper.Map<Student>(request.dto);
            await _repo.AddAsync(Student);
            var studentDto = _mapper.Map<StudentDto>(Student);
            return ResultT<StudentDto>.Success(studentDto);
        }
    }
}
