using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Requests.Queries;

namespace TraineeTracker.Application.Features.Trackers.Handlers.Queries
{
    public class GetTrackerListByTrainerRequestHandler : IRequestHandler<GetTrackerListByTrainerRequest, List<TrackerListDto>>
    {
        private readonly ITrackerRepository _trackerRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetTrackerListByTrainerRequestHandler(ITrackerRepository trackerRepository, 
            IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _trackerRepository = trackerRepository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<TrackerListDto>> Handle(GetTrackerListByTrainerRequest request, CancellationToken cancellationToken)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

            var trackers = await _trackerRepository.GetTrackersByTrainer(userId);
            return _mapper.Map<List<TrackerListDto>>(trackers);
        }
    }
}
