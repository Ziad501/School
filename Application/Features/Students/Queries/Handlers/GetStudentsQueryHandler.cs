using Application.DTOs.StudentDtos;
using Application.Features.Students.Queries.Models;
using Application.Interfaces;
using Domain.Abstractions;
using MapsterMapper;
using MediatR;

namespace Application.Features.Students.Queries.Handlers
{
    public class GetStudentsQueryHandler(IStudentService _service, IMapper _mapper) : IRequestHandler<GetStudentsQuery, ResultT<PagedList<StudentDto>>>, IRequestHandler<GetStudentsByIdQuery, ResultT<StudentDto>>
    {
        public async Task<ResultT<PagedList<StudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _service.GetAllStudents(request.page, request.pageSize, cancellationToken);
            var studentDtoPagedList = new PagedList<StudentDto>(
                _mapper.Map<List<StudentDto>>(studentList.Value.Items),
                studentList.Value.TotalCount,
                studentList.Value.CurrentPage,
                studentList.Value.PageSize
            );
            return ResultT<PagedList<StudentDto>>.Success(studentDtoPagedList);
        }

        public async Task<ResultT<StudentDto>> Handle(GetStudentsByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _service.GetStudentById(request.Id, cancellationToken);
            if (student.IsFailure)
            {
                return ResultT<StudentDto>.Failure(student.Error);
            }
            var studentDto = _mapper.Map<StudentDto>(student.Value);
            return ResultT<StudentDto>.Success(studentDto);

        }
    }
}
