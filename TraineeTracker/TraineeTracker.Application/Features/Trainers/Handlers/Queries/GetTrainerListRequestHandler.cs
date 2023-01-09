using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.Features.Trainers.Requests.Queries;

namespace TraineeTracker.Application.Features.Trainers.Handlers.Queries
{
    public class GetTrainerListRequestHandler : IRequestHandler<GetTrainerListRequest, List<TrainerDto>>
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public GetTrainerListRequestHandler(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task<List<TrainerDto>> Handle(GetTrainerListRequest request, CancellationToken cancellationToken)
        {
            var trainers = await _trainerRepository.GetTrainersWithDetails();
            return _mapper.Map<List<TrainerDto>>(trainers);
        }
    }
}
