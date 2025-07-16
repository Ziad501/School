using Application.DTOs.StudentDtos;
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
        public async Task<ActionResult<ResultT<List<StudentDto>>>> GetAllStudents(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetStudentsQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResultT<StudentDto>>> GetStudentById(Guid id,CancellationToken cancellationToken)
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
    }
}
