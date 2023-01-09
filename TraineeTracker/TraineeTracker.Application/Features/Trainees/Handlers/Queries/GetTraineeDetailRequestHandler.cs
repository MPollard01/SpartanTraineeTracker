using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;

namespace TraineeTracker.Application.Features.Trainees.Handlers.Queries
{
    public class GetTraineeDetailRequestHandler : IRequestHandler<GetTraineeDetailRequest, TraineeDto>
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IMapper _mapper;

        public GetTraineeDetailRequestHandler(ITraineeRepository traineeRepository, IMapper mapper)
        {
            _traineeRepository = traineeRepository;
            _mapper = mapper;
        }

        public async Task<TraineeDto> Handle(GetTraineeDetailRequest request, CancellationToken cancellationToken)
        {
            var trainee = await _traineeRepository.GetTraineeWithDetails(request.Id);
            return _mapper.Map<TraineeDto>(trainee);
        }
    }
}
