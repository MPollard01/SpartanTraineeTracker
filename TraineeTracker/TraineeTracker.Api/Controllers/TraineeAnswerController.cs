using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.TraineeAnswer;
using TraineeTracker.Application.Features.TraineeAnswers.Requests.Commands;
using TraineeTracker.Application.Features.TraineeAnswers.Requests.Queries;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TraineeAnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TraineeAnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{testId}")]
        public async Task<ActionResult<List<TraineeAnswerDto>>> Get(int testId)
        {
            var answers = await _mediator.Send(new GetTraineeAnswerListByTraineeTestIdRequest { TraineeTestId = testId });
            return Ok(answers);
        }

        [Authorize(Roles = "Trainee")]
        [HttpGet("{testId}/{questionId}")]
        [EndpointName("TraineeAnswerGETAnswersByQuestionId")]
        public async Task<ActionResult<List<TraineeAnswerDto>>> Get(int testId, int questionId)
        {
            var answers = await _mediator
                .Send(new GetTraineeAnswerListByTestAndQuestionIdRequest
                {
                    TestId = testId,
                    QuestionId = questionId
                });
            return Ok(answers);
        }

        [Authorize(Roles = "Trainee")]
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeAnswerDto answerDto)
        {
            var command = new CreateTraineeAnswerCommand { TraineeDto = answerDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
