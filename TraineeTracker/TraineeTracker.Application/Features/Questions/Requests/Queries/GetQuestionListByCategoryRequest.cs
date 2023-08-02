using MediatR;
using TraineeTracker.Application.DTOs.Question;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.Questions.Requests.Queries
{
    public class GetQuestionListByCategoryRequest : IRequest<List<QuestionDto>>
    {
        public string Category { get; set; }
    }
}
