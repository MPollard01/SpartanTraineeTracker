using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TraineeTest;
using TraineeTracker.Application.Features.TraineeTests.Requests.Queries;

namespace TraineeTracker.Application.Features.TraineeTests.Handlers.Queries
{
    public class GetTraineeTestByLatestDateRequestHandler : IRequestHandler<GetTraineeTestByLatestDateRequest, TraineeTestDetailDto>
    {
        private readonly ITraineeTestRepository _traineeTestRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTraineeTestByLatestDateRequestHandler(ITraineeTestRepository traineeTestRepository, 
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _traineeTestRepository = traineeTestRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TraineeTestDetailDto> Handle(GetTraineeTestByLatestDateRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

            var test = await _traineeTestRepository.GetTraineeTestWithAnswersByLatestDate(userId);
            return _mapper.Map<TraineeTestDetailDto>(test);
        }
    }
}
