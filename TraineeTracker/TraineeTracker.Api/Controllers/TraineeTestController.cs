using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.TraineeTest;
using TraineeTracker.Application.Features.TraineeTests.Requests.Commands;
using TraineeTracker.Application.Features.TraineeTests.Requests.Queries;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TraineeTestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TraineeTestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TraineeTestDto>>> GetAll()
        {
            var tests = await _mediator.Send(new GetTraineeTestListRequest());
            return Ok(tests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TraineeTestDetailDto>> Get(int id)
        {
            var test = await _mediator.Send(new GetTraineeTestDetailRequest { Id = id });
            return Ok(test);
        }

        [HttpGet("LatestTestId")]
        [EndpointName("TraineeTestGETLatestTestId")]
        public async Task<ActionResult<int>> Get()
        {
            int id = await _mediator.Send(new GetTraineeTestIdByLatestDateRequest());
            return Ok(id);
        }

        [HttpGet("LatestTest")]
        [EndpointName("TraineeTestGETLatestTest")]
        public async Task<ActionResult<TraineeTestDetailDto>> GetLatest()
        {
            var test = await _mediator.Send(new GetTraineeTestByLatestDateRequest());
            return Ok(test);
        }

        [HttpGet("LatestTestWithCategory")]
        [EndpointName("TraineeTestGETLatestTestWithCategory")]
        public async Task<ActionResult<TraineeTestWithCategoryDto>> GetLatestWithCategory()
        {
            var test = await _mediator.Send(new GetTraineeTestWithCategoryByLatestDateRequest());
            return Ok(test);
        }

        [HttpPost]
        [Authorize(Roles = "Trainee")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeTestDto testDto)
        {
            var command = new CreateTraineeTestCommand { TraineeTestDto = testDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [Authorize(Roles = "Trainee")]
        public async Task<ActionResult<Unit>> Put(int id, int traineeAnswerId, int questionNum)
        {
            var command = new UpdateTraineeTestScoreCommand
            {
                TraineeTestId = id,
                TraineeAnswerId = traineeAnswerId,
                Index = questionNum,
            };

            await _mediator.Send(command);
            return NoContent();
        }

    }
}
