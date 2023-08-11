using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker.Validators;
using TraineeTracker.Application.Features.Trackers.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.Trackers.Handlers.Commands
{
    public class CreateTrackerCommandHandler : IRequestHandler<CreateTrackerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTrackerCommandHandler(IUnitOfWork uow, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseCommandResponse> Handle(CreateTrackerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTrackerDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TrackerDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var tracker = _mapper.Map<Tracker>(request.TrackerDto);
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

                tracker.TraineeId = userId;
                tracker.StartDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
                tracker.CreatedDate = DateTime.UtcNow;
                tracker.CreatedBy = userId;

                tracker = await _uow.TrackerRepository.Add(tracker);
                await _uow.Save();

                response.Success = true;
                response.Message = "Creation Successfull";
                response.Id = tracker.Id;
            }

            return response;
        }
    }
}
