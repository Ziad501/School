//using Application.Features.DTOs;
//using Application.Features.Students.Queries.Models;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Presentation.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController(IMediator _mediator): ControllerBase
//    {
//        [HttpGet]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        public async Task<ActionResult<List<StudentDto>>> GetAllStudents(CancellationToken cancellationToken)
//        {
//            var response = await _mediator.Send(new GetStudentsQuery(),cancellationToken);
//            return Ok(response);

//        }
//    }
//}
