using MediatR;
using TraineeTracker.Application.DTOs.SubCategory;

namespace TraineeTracker.Application.Features.SubCategories.Requests.Queries
{
    public class GetSubCategoryListRequest : IRequest<List<SubCategoryDto>>
    {
        public string Category { get; set; }
    }
}
