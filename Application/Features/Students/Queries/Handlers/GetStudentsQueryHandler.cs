using Application.DTOs.StudentDtos;
using Application.Features.Students.Queries.Models;
using Application.Interfaces;
using Domain.Abstractions;
using MapsterMapper;
using MediatR;

namespace Application.Features.Students.Queries.Handlers
{
    public class GetStudentsQueryHandler(IStudentRepository _repo, IMapper _mapper) : IRequestHandler<GetStudentsQuery, ResultT<List<StudentDto>>>, IRequestHandler<GetStudentsByIdQuery, ResultT<StudentDto>>
    {
        public async Task<ResultT<List<StudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _repo.GetAllStudents(cancellationToken);
            var studentDto = _mapper.Map<List<StudentDto>>(studentList);
            return ResultT<List<StudentDto>>.Success(studentDto);
        }

        public async Task<ResultT<StudentDto>> Handle(GetStudentsByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByIdAsync(request.Id, cancellationToken);
            if (student == null)
                return Errors.NotFound;
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;

        }
    }
}
