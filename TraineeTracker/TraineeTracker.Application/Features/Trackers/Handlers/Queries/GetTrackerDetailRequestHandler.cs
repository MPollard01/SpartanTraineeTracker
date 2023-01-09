using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Requests.Queries;

namespace TraineeTracker.Application.Features.Trackers.Handlers.Queries
{
    public class GetTrackerDetailRequestHandler : IRequestHandler<GetTrackerDetailRequest, TrackerDto>
    {
        private readonly ITrackerRepository _trackerRepository;
        private readonly IMapper _mapper;

        public GetTrackerDetailRequestHandler(ITrackerRepository trackerRepository, IMapper mapper)
        {
            _trackerRepository = trackerRepository;
            _mapper = mapper;
        }

        public async Task<TrackerDto> Handle(GetTrackerDetailRequest request, CancellationToken cancellationToken)
        {
            var tracker = await _trackerRepository.GetTrackerWithDetails(request.Id);
            return _mapper.Map<TrackerDto>(tracker);
        }
    }
}
