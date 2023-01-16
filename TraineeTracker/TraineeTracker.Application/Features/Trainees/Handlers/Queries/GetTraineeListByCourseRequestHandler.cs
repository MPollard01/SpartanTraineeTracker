using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;

namespace TraineeTracker.Application.Features.Trainees.Handlers.Queries
{
    public class GetTraineeListByCourseRequestHandler : IRequestHandler<GetTraineeListByCourseRequest, List<TraineeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITraineeRepository _traineeRepository;

        public GetTraineeListByCourseRequestHandler(IMapper mapper, ITraineeRepository traineeRepository)
        {
            _mapper = mapper;
            _traineeRepository = traineeRepository;
        }

        public async Task<List<TraineeDto>> Handle(GetTraineeListByCourseRequest request, CancellationToken cancellationToken)
        {
            var trainees = await _traineeRepository.GetTraineesByCourse(request.Id);
            return _mapper.Map<List<TraineeDto>>(trainees);
        }
    }
}
