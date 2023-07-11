using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Requests.Commands;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TraineeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TraineeDto>>> Get()
        {
            var trainees = await _mediator.Send(new GetTraineeListRequest());
            return Ok(trainees);
        }

        [HttpGet("course")]
        [EndpointName("TraineeAllByCourse")]
        public async Task<ActionResult<List<TraineeDto>>> GetByCourse(int courseId)
        {
            var trainees = await _mediator.Send(new GetTraineeListByCourseRequest { Id = courseId});
            return Ok(trainees);
        }

        [Authorize(Roles = "Trainer")]
        [HttpGet("trainer")]
        [EndpointName("TraineeAllByTrainer")]
        public async Task<ActionResult<List<TraineeCourseDto>>> GetTrainees()
        {
            var trainees = await _mediator.Send(new GetTraineeListByTrainerRequest());
            return Ok(trainees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TraineeDetailDto>> Get(string id)
        {
            var trainer = await _mediator.Send(new GetTraineeDetailRequest { Id = id });
            return Ok(trainer);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeDto traineeDto) 
        { 
            var command = new CreateTraineeCommand { TraineeDto = traineeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
