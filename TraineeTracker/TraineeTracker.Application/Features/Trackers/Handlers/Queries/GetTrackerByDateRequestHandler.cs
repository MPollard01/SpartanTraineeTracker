using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Requests.Queries;

namespace TraineeTracker.Application.Features.Trackers.Handlers.Queries
{
    public class GetTrackerByDateRequestHandler : IRequestHandler<GetTrackerByDateRequest, TrackerDto>
    {
        private readonly IMapper _mapper;
        private readonly ITrackerRepository _trackerRepository;
        private readonly IHttpContextAccessor _httpContext;

        public GetTrackerByDateRequestHandler(IMapper mapper, IHttpContextAccessor httpContext,
            ITrackerRepository trackerRepository)
        {
            _mapper = mapper;
            _trackerRepository = trackerRepository;
            _httpContext = httpContext;
        }

        public async Task<TrackerDto> Handle(GetTrackerByDateRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContext.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;
            var tracker = await _trackerRepository.GetTrackerByDate(request.Date, userId);
            return _mapper.Map<TrackerDto>(tracker);
        }
    }
}
