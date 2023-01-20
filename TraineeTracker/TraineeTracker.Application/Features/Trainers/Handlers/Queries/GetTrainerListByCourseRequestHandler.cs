using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.Features.Trainers.Requests.Queries;

namespace TraineeTracker.Application.Features.Trainers.Handlers.Queries
{
    public class GetTrainerListByCourseRequestHandler : IRequestHandler<GetTrainerListByCourseRequest, List<TrainerDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITrainerRepository _trainerRepository;

        public GetTrainerListByCourseRequestHandler(IMapper mapper, ITrainerRepository trainerRepository)
        {
            _mapper = mapper;
            _trainerRepository = trainerRepository;
        }

        public async Task<List<TrainerDto>> Handle(GetTrainerListByCourseRequest request, CancellationToken cancellationToken)
        {
            var trainers = await _trainerRepository.GetTrainersByCourse(request.Id);
            return _mapper.Map<List<TrainerDto>>(trainers);
        }
    }
}
