using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.Question;
using TraineeTracker.Application.Features.Questions.Requests.Queries;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuestionDto>>> Get(string category)
        {
            var questions = await _mediator.Send(new GetQuestionListByCategoryRequest { Category = category });
            return Ok(questions);
        }

        [HttpGet("{category}")]
        public async Task<ActionResult<QuestionDto>> Get(string category, int index)
        {
            var question = await _mediator.Send(new GetQuestionByCategoryRequest { Category = category, Index = index });
            return Ok(question);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount(string category)
        {
            return await _mediator.Send(new GetQuestionCountByCategoryRequest { Category = category });
        }
    }
}
