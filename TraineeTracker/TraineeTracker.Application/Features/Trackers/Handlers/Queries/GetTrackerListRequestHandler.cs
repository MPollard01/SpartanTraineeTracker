using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Requests.Queries;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.Trackers.Handlers.Queries
{
    public class GetTrackerListRequestHandler : IRequestHandler<GetTrackerListRequest, List<TrackerListDto>>
    {
        private readonly ITrackerRepository _trackerRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTrackerListRequestHandler(ITrackerRepository trackerRepository, IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _trackerRepository = trackerRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<TrackerListDto>> Handle(GetTrackerListRequest request, CancellationToken cancellationToken)
        {
            var trackers = new List<Tracker>();

            if (request.IsTraineeLoggedIn)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;
                trackers = await _trackerRepository.GetTrackersWithDetails(userId);
            }
            else
            {
                trackers = await _trackerRepository.GetTrackersWithDetails();
            }

            return _mapper.Map<List<TrackerListDto>>(trackers);
        }
    }
}
