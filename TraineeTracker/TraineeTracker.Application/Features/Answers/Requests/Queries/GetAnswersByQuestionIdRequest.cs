using MediatR;
using TraineeTracker.Application.DTOs.Answer;

namespace TraineeTracker.Application.Features.Answers.Requests.Queries
{
    public class GetAnswersByQuestionIdRequest : IRequest<List<AnswerDto>>
    {
        public int QuestionId { get; set; }
    }
}
