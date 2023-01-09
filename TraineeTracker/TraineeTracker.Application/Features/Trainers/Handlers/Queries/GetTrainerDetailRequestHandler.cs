using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.Features.Trainers.Requests.Queries;

namespace TraineeTracker.Application.Features.Trainers.Handlers.Queries
{
    public class GetTrainerDetailRequestHandler : IRequestHandler<GetTrainerDetailRequest, TrainerDto>
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public GetTrainerDetailRequestHandler(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task<TrainerDto> Handle(GetTrainerDetailRequest request, CancellationToken cancellationToken)
        {
            var trainer = await _trainerRepository.GetTrainerWithDetails(request.Id);
            return _mapper.Map<TrainerDto>(trainer);
        }
    }
}
