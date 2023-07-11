using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.Features.Trainers.Requests.Commands;
using TraineeTracker.Application.Features.Trainers.Requests.Queries;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainerDto>>> Get()
        {
            var trainers = await _mediator.Send(new GetTrainerListRequest());
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerDetailDto>> Get(string id)
        {
            var trainer = await _mediator.Send(new GetTrainerDetailRequest { Id = id });
            return Ok(trainer);
        }

        [HttpGet("course")]
        [EndpointName("TrainerAllByCourse")]
        public async Task<ActionResult<List<TrainerDto>>> GetByCourse(int courseId)
        {
            var trainees = await _mediator.Send(new GetTrainerListByCourseRequest { Id = courseId });
            return Ok(trainees);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTrainerDto trainerDto)
        {
            var command = new CreateTrainerCommand { TrainerDto = trainerDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
