using MediatR;
using TraineeTracker.Application.DTOs.Category;

namespace TraineeTracker.Application.Features.Categories.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<List<CategoryDetailDto>>
    {

    }
}
