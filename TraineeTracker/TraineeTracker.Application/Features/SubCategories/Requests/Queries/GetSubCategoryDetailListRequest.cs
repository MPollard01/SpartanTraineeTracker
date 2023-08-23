using MediatR;
using TraineeTracker.Application.DTOs.SubCategory;

namespace TraineeTracker.Application.Features.SubCategories.Requests.Queries
{
    public class GetSubCategoryDetailListRequest : IRequest<List<SubCategoryDetailDto>>
    {
    }
}
