using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.Answer;
using TraineeTracker.Application.Features.Answers.Requests.Queries;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{questionId}")]
        public async Task<ActionResult<List<AnswerDto>>> Get(int questionId)
        {
            var answers = await _mediator.Send(new GetAnswersByQuestionIdRequest { QuestionId = questionId });
            return Ok(answers);
        }

        [HttpGet("/count/{questionId}")]
        [EndpointName("AnswerGETCountAsync")]
        public async Task<ActionResult<int>> GetCount(int questionId)
        {
            var count = await _mediator.Send(new GetAnswerCountRequest { QuestionId = questionId });
            return Ok(count);
        }

        [HttpGet("/totalcount/{categoryId}")]
        [EndpointName("AnswerGETCountTotalAsync")]
        public async Task<ActionResult<int>> GetCountTotal(int categoryId)
        {
            var count = await _mediator.Send(new GetAnswerCountTotalRequest { CategoryId = categoryId });
            return Ok(count);
        }
    }
}
