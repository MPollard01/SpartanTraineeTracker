using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.Features.Courses.Requests.Commands;
using TraineeTracker.Application.Features.Courses.Requests.Queries;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> Get()
        {
            var courses = await _mediator.Send(new GetCourseListRequest());
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var course = await _mediator.Send(new GetCourseRequest { Id = id });
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseDto courseDto)
        {
            var command = new CreateCourseCommand { CourseDto = courseDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
