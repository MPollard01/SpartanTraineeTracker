using MediatR;

namespace TraineeTracker.Application.Features.Answers.Requests.Queries
{
    public class GetAnswerCountTotalRequest : IRequest<int>
    {
        public int CategoryId { get; set; }
    }
}
