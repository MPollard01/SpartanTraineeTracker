using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Requests.Queries;

namespace TraineeTracker.Application.Features.Trackers.Handlers.Queries
{
    public class GetTrackerListByTraineeIdRequestHandler : IRequestHandler<GetTrackerListByTraineeIdRequest, List<TrackerDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITrackerRepository _trackerRepository;

        public GetTrackerListByTraineeIdRequestHandler(IMapper mapper, ITrackerRepository trackerRepository)
        {
            _mapper = mapper;
            _trackerRepository = trackerRepository;
        }

        public async Task<List<TrackerDto>> Handle(GetTrackerListByTraineeIdRequest request, CancellationToken cancellationToken)
        {
            var trackers = await _trackerRepository.GetTrackersWithDetails(request.Id);
            return _mapper.Map<List<TrackerDto>>(trackers);
        }
    }
}
