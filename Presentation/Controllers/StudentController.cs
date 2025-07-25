using Application.DTOs.StudentDtos;
using Application.Features;
using Application.Features.Students.Commands.Models;
using Application.Features.Students.Queries.Models;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ResultT<PagedList<StudentDto>>>> GetAllStudents(
        int page,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetStudentsQuery(page, pageSize), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ResultT<StudentDto>>> GetStudentById(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetStudentsByIdQuery(id), cancellationToken);
        if (response.IsFailure)
        {
            return response.Error.code switch
            {
                "NotFound" => NotFound(response.Error),
                _ => BadRequest(response.Error)
            };
        }
        return Ok(response);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ResultT<StudentDto>>> AddStudent(
        StudentCreateDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new AddStudentCommand(dto), cancellationToken);
        if (response.IsFailure)
        {
            if (response.Error == Errors.NullValue)
                return BadRequest("student fields shouldn't be empty");
        }
        return Ok(response);
    }
    [HttpPut("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<Result>> UpdateStudent(
        [FromRoute] Guid id,
        [FromBody] StudentUpdateDto dto,
        CancellationToken cancellationToken)
    {
        if (id != dto.Id)
            return BadRequest(Errors.IdMissMatch);

        var response = await _mediator.Send(new UpdateStudentCommand(dto), cancellationToken);
        if (response.IsFailure)
        {
            return response.Error.code switch
            {
                "NotFound" => NotFound(response.Error),
                "MissingFields" => BadRequest(response.Error),
                "Validation failed" => BadRequest(response.Error),
                _ => BadRequest(new Error("ServerError", "An unexpected error occurred."))
            };
        }
        return NoContent();
    }
    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Result>> DeleteAsync([FromRoute] Guid id, CancellationToken cancellation)
    {
        var response = await _mediator.Send(new DeleteStudentCommand(id), cancellation);
        if (response.IsFailure)
        {
            if (response.Error == Errors.NotFound)
                return NotFound(Errors.NotFound.description);

            return BadRequest(response.Error);
        }
        return Result.Success();
    }
}
