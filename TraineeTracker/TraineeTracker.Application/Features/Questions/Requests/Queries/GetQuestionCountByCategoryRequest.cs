using MediatR;

namespace TraineeTracker.Application.Features.Questions.Requests.Queries
{
    public class GetQuestionCountByCategoryRequest : IRequest<int>
    {
        public string Category { get; set; }
    }
}
