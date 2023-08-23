using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.Category;
using TraineeTracker.Application.Features.Categories.Requests.Queries;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDetailDto>>> Get()
        {
            var categories = await _mediator.Send(new GetCategoryListRequest());
            return Ok(categories);
        }
    }
}
