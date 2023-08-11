using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("/count/{questionId}")]
        [EndpointName("AnswerGETCountAsync")]
        public async Task<ActionResult<int>> GetCount(int questionId)
        {
            var count = await _mediator.Send(new GetAnswerCountRequest { QuestionId = questionId });
            return Ok(count);
        }
    }
}
