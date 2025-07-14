//using Application.Features.DTOs;
//using Application.Features.Students.Queries.Models;
//using Application.Interfaces;
//using Domain.Abstractions;
//using Domain.Entities;
//using Mapster;
//using MapsterMapper;
//using MediatR;

//namespace Application.Features.Students.Queries.Handlers
//{
//    public class GetStudentsHandler(IStudentRepository _repo, IMapper _mapper) : IRequestHandler<GetStudentsQuery, ResultT<List<StudentDto>>>
//    {
//        public async Task<ResultT<List<StudentDto>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
//        {
//            var students = await _repo.GetAllAsync(cancellationToken);
//            var studnetsDto = _mapper.Map<List<StudentDto>>(students);
//            return ResultT<List<StudentDto>>.Success(studnetsDto);
//        }

//    }
//}
