using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TraineeAnswer;
using TraineeTracker.Application.Features.TraineeAnswers.Requests.Queries;

namespace TraineeTracker.Application.Features.TraineeAnswers.Handlers.Queries
{
    public class GetTraineeAnswerListByTestAndQuestionIdRequestHandler : IRequestHandler<GetTraineeAnswerListByTestAndQuestionIdRequest, List<TraineeAnswerDto>>
    {
        private readonly ITraineeAnswerRepository _traineeAnswerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public GetTraineeAnswerListByTestAndQuestionIdRequestHandler(ITraineeAnswerRepository traineeAnswerRepository, 
            IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _traineeAnswerRepository = traineeAnswerRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<List<TraineeAnswerDto>> Handle(GetTraineeAnswerListByTestAndQuestionIdRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

            var answers = await _traineeAnswerRepository
                .GetTraineeAnswersByTraineeTestIdAndQuestionId(request.TestId, request.QuestionId, userId);

            return _mapper.Map<List<TraineeAnswerDto>>(answers);
        }
    }
}
