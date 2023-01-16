using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;

namespace TraineeTracker.Application.Features.Trainees.Handlers.Queries
{
    public class GetTraineeListRequestHandler : IRequestHandler<GetTraineeListRequest, List<TraineeDto>>
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IMapper _mapper;

        public GetTraineeListRequestHandler(ITraineeRepository traineeRepository, IMapper mapper)
        {
            _traineeRepository = traineeRepository;
            _mapper = mapper;
        }

        public async Task<List<TraineeDto>> Handle(GetTraineeListRequest request, CancellationToken cancellationToken)
        {
            var trainees = await _traineeRepository.GetAll();
            return _mapper.Map<List<TraineeDto>>(trainees);
        }
    }
}
