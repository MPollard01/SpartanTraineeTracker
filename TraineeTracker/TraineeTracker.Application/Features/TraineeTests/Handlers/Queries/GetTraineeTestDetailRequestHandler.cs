using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TraineeTest;
using TraineeTracker.Application.Features.TraineeTests.Requests.Queries;

namespace TraineeTracker.Application.Features.TraineeTests.Handlers.Queries
{
    public class GetTraineeTestDetailRequestHandler : IRequestHandler<GetTraineeTestDetailRequest, TraineeTestDetailDto>
    {
        private readonly ITraineeTestRepository _traineeTestRepository;
        private readonly IMapper _mapper;

        public GetTraineeTestDetailRequestHandler(ITraineeTestRepository traineeTestRepository, IMapper mapper)
        {
            _traineeTestRepository = traineeTestRepository;
            _mapper = mapper;
        }

        public async Task<TraineeTestDetailDto> Handle(GetTraineeTestDetailRequest request, CancellationToken cancellationToken)
        {
            var test = await _traineeTestRepository.GetTraineeTestWithAnswersById(request.Id);
            return _mapper.Map<TraineeTestDetailDto>(test);
        }
    }
}
