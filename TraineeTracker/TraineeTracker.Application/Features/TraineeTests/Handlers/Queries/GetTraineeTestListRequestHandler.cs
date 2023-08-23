using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TraineeTest;
using TraineeTracker.Application.Features.TraineeTests.Requests.Queries;

namespace TraineeTracker.Application.Features.TraineeTests.Handlers.Queries
{
    public class GetTraineeTestListRequestHandler : IRequestHandler<GetTraineeTestListRequest, List<TraineeTestDto>>
    {
        private readonly ITraineeTestRepository _traineeTestRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTraineeTestListRequestHandler(ITraineeTestRepository traineeTestRepository, 
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _traineeTestRepository = traineeTestRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<TraineeTestDto>> Handle(GetTraineeTestListRequest request, CancellationToken cancellationToken)
        {
            var traineeId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

            var tests = await _traineeTestRepository.GetTraineeTestsWithCategoryByTraineeId(traineeId);
            return _mapper.Map<List<TraineeTestDto>>(tests);
        }
    }
}
