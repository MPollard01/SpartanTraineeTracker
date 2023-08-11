using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TraineeTest.Validators;
using TraineeTracker.Application.Features.TraineeTests.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.TraineeTests.Handlers.Commands
{
    public class CreateTraineeTestCommandHandler : IRequestHandler<CreateTraineeTestCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTraineeTestCommandHandler(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeTestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeTestDtoValidator(_uow.SubCategoryRepository);
            var validationResult = await validator.ValidateAsync(request.TraineeTestDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var traineeTest = _mapper.Map<TraineeTest>(request.TraineeTestDto);

                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

                traineeTest.TraineeId = userId;
                traineeTest.CreatedDate = DateTime.UtcNow;

                traineeTest = await _uow.TraineeTestRepository.Add(traineeTest);
                await _uow.Save();

                response.Success = true;
                response.Message = "Creation Successfull";
                response.Id = traineeTest.Id;
            }

            return response;
        }
    }
}
