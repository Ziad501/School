using Application.DTOs.StudentCourseDtos;
using Application.DTOs.StudentDtos;
using Application.Features;
using Application.Features.Students.Commands.Models;
using Application.Features.Students.Queries.Models;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResultT<PagedList<StudentDto>>>> GetAllStudents(int page , int pageSize,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetStudentsQuery(page,pageSize), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResultT<StudentDto>>> GetStudentById([FromRoute]Guid id,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetStudentsByIdQuery(id), cancellationToken);
            if (response.IsFailure)
            {
                if (response.Error == Errors.NotFound)
                {
                    return NotFound();
                }
                return BadRequest("the student found but something else happened");
            }
            return Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResultT<StudentDto>>> AddStudent(StudentCreateDto dto,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new AddStudentCommand(dto), cancellationToken);
            if(response.IsFailure)
            {
                if (response.Error == Errors.NullValue)
                    return BadRequest("student fields shouldn't be empty");
            }
            return Ok(response);
        }
    }
}
