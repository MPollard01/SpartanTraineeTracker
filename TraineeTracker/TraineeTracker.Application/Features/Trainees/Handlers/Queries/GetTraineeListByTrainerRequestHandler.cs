using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;

namespace TraineeTracker.Application.Features.Trainees.Handlers.Queries
{
    public class GetTraineeListByTrainerRequestHandler : IRequestHandler<GetTraineeListByTrainerRequest, List<TraineeCourseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITraineeRepository _traineeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTraineeListByTrainerRequestHandler(IMapper mapper, 
            ITraineeRepository traineeRepository, IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _traineeRepository = traineeRepository;
            _httpContextAccessor = httpContext;
        }

        public async Task<List<TraineeCourseDto>> Handle(GetTraineeListByTrainerRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

            var trainees = await _traineeRepository.GetTraineesWithCourse(userId);
            return _mapper.Map<List<TraineeCourseDto>>(trainees);
        }
    }
}
