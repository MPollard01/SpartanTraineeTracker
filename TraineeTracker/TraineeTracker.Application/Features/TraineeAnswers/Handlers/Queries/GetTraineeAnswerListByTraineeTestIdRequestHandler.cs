using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TraineeAnswer;
using TraineeTracker.Application.Features.TraineeAnswers.Requests.Queries;

namespace TraineeTracker.Application.Features.TraineeAnswers.Handlers.Queries
{
    public class GetTraineeAnswerListByTraineeTestIdRequestHandler : IRequestHandler<GetTraineeAnswerListByTraineeTestIdRequest, List<TraineeAnswerDto>>
    {
        private readonly ITraineeAnswerRepository _traineeAnswerRepository;
        private readonly IMapper _mapper;

        public GetTraineeAnswerListByTraineeTestIdRequestHandler(ITraineeAnswerRepository traineeAnswerRepository, IMapper mapper)
        {
            _traineeAnswerRepository = traineeAnswerRepository;
            _mapper = mapper;
        }

        public async Task<List<TraineeAnswerDto>> Handle(GetTraineeAnswerListByTraineeTestIdRequest request, CancellationToken cancellationToken)
        {
            var answers = await _traineeAnswerRepository.GetTraineeAnswersByTraineeTestId(request.TraineeTestId);
            return _mapper.Map<List<TraineeAnswerDto>>(answers);
        }
    }
}
