using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.Features.Answers.Requests.Queries;

namespace TraineeTracker.Application.Features.Answers.Handlers.Queries
{
    public class GetAnswerCountRequestHandler : IRequestHandler<GetAnswerCountRequest, int>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerCountRequestHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<int> Handle(GetAnswerCountRequest request, CancellationToken cancellationToken)
        {
            return await _answerRepository.GetAnswerCountByQuestionId(request.QuestionId);
        }
    }
}
