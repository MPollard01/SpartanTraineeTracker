using MediatR;
using TraineeTracker.Application.DTOs.TraineeAnswer;

namespace TraineeTracker.Application.Features.TraineeAnswers.Requests.Queries
{
    public class GetTraineeAnswerListByTraineeTestIdRequest : IRequest<List<TraineeAnswerDto>>
    {
        public int TraineeTestId { get; set; }
    }
}
