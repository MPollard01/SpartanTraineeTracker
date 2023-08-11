using MediatR;

namespace TraineeTracker.Application.Features.Answers.Requests.Queries
{
    public class GetAnswerCountRequest : IRequest<int>
    {
        public int QuestionId { get; set; }
    }
}
