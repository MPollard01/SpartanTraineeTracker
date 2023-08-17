using MediatR;
using TraineeTracker.Application.DTOs.TraineeAnswer;

namespace TraineeTracker.Application.Features.TraineeAnswers.Requests.Queries
{
    public class GetTraineeAnswerListByTestAndQuestionIdRequest : IRequest<List<TraineeAnswerDto>>
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
    }
}
