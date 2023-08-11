using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.DTOs.SubCategory;
using TraineeTracker.Application.Features.SubCategories.Requests.Queries;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDto>>> Get(string category)
        {
            var categories = await _mediator.Send(new GetSubCategoryListRequest { Category = category });
            return Ok(categories);
        }
    }
}
