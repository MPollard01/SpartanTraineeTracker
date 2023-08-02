using MediatR;
using TraineeTracker.Application.DTOs.Question;

namespace TraineeTracker.Application.Features.Questions.Requests.Queries
{
    public class GetQuestionDetailRequest : IRequest<QuestionDto>
    {
        public int Id { get; set; }
    }
}
