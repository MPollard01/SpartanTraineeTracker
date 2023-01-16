using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.TrainerTrainee;
using TraineeTracker.Application.Features.TrainerTrainees.Requests.Commands;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerTraineeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainerTraineeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTrainerTraineeDto trainerTraineeDto)
        {
            var command = new CreateTrainerTraineeCommand { TrainerTraineeDto = trainerTraineeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
