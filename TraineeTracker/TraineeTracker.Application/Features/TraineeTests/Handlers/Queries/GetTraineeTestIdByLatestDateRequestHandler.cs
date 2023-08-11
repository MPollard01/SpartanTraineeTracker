using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.Features.TraineeTests.Requests.Queries;

namespace TraineeTracker.Application.Features.TraineeTests.Handlers.Queries
{
    public class GetTraineeTestIdByLatestDateRequestHandler : IRequestHandler<GetTraineeTestIdByLatestDateRequest, int>
    {
        private readonly ITraineeTestRepository _traineeTestRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTraineeTestIdByLatestDateRequestHandler(ITraineeTestRepository traineeTestRepository, IHttpContextAccessor httpContextAccessor)
        {
            _traineeTestRepository = traineeTestRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Handle(GetTraineeTestIdByLatestDateRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

            return await _traineeTestRepository.GetTraineeTestIdByLatestDate(userId);
        }
    }
}
