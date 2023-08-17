using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Answer;
using TraineeTracker.Application.Features.Answers.Requests.Queries;

namespace TraineeTracker.Application.Features.Answers.Handlers.Queries
{
    public class GetAnswersByQuestionIdRequestHandler : IRequestHandler<GetAnswersByQuestionIdRequest, List<AnswerDto>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public GetAnswersByQuestionIdRequestHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<AnswerDto>> Handle(GetAnswersByQuestionIdRequest request, CancellationToken cancellationToken)
        {
            var answers = await _answerRepository.GetAnswersByQuestionId(request.QuestionId);
            return _mapper.Map<List<AnswerDto>>(answers);
        }
    }
}
