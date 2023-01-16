using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.TrainerCourse;
using TraineeTracker.Application.Features.TrainerCourses.Requests.Commands;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerCourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainerCourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTrainerCourseDto dto)
        {
            var command = new CreateTrainerCourseCommand { TrainerCourseDto = dto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
