using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.Features.Questions.Requests.Queries;

namespace TraineeTracker.Application.Features.Questions.Handlers.Queries
{
    public class GetQuestionCountByCategoryRequestHandler : IRequestHandler<GetQuestionCountByCategoryRequest, int>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionCountByCategoryRequestHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<int> Handle(GetQuestionCountByCategoryRequest request, CancellationToken cancellationToken)
        {
            return await _questionRepository.GetQuestionCountByCategory(request.Category);
        }
    }
}
