using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TraineeAnswer.Validators;
using TraineeTracker.Application.Features.TraineeAnswers.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.TraineeAnswers.Handlers.Commands
{
    public class CreateTraineeAnswerCommandHandler : IRequestHandler<CreateTraineeAnswerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTraineeAnswerCommandHandler(IUnitOfWork uow, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeAnswerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeAnswerDtoValidator(_uow.TraineeTestRepository);
            var validationResult = await validator.ValidateAsync(request.TraineeDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var traineeAnswer = _mapper.Map<TraineeAnswer>(request.TraineeDto);

                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;

                traineeAnswer.TraineeId = userId;

                traineeAnswer = await _uow.TraineeAnswerRepository.Add(traineeAnswer);
                await _uow.Save();

                response.Success = true;
                response.Message = "Creation Successfull";
                response.Id = traineeAnswer.Id;
            }

            return response;
        }
    }
}
