using MediatR;
using TraineeTracker.Application.DTOs.Question;

namespace TraineeTracker.Application.Features.Questions.Requests.Queries
{
    public class GetQuestionByCategoryRequest : IRequest<QuestionDto>
    {
        public string Category { get; set; }
        public int Index { get; set; }
    }
}
