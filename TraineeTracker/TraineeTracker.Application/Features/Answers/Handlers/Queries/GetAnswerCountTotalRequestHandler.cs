using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.Features.Answers.Requests.Queries;

namespace TraineeTracker.Application.Features.Answers.Handlers.Queries
{
    public class GetAnswerCountTotalRequestHandler : IRequestHandler<GetAnswerCountTotalRequest, int>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerCountTotalRequestHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<int> Handle(GetAnswerCountTotalRequest request, CancellationToken cancellationToken)
        {
            return await _answerRepository.GetAnswerCountByCategoryId(request.CategoryId);
        }
    }
}
