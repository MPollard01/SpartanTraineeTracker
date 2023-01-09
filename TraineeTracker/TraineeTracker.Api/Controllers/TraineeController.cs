using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Requests.Commands;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TraineeDto>> Get(string id)
        {
            var trainer = await _mediator.Send(new GetTraineeDetailRequest { Id = id });
            return Ok(trainer);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeDto traineeDto) 
        { 
            var command = new CreateTraineeCommand { TraineeDto = traineeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
