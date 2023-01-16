using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.TrainerTrainee.Validators;
using TraineeTracker.Application.Features.TrainerTrainees.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.TrainerTrainees.Handlers.Commands
{
    public class CreateTrainerTraineeCommandHandler : IRequestHandler<CreateTrainerTraineeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateTrainerTraineeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTrainerTraineeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTrainerTraineeDtoValidator(_uow);
            var validationResult = await validator.ValidateAsync(request.TrainerTraineeDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var trainerTrainee = _mapper.Map<TrainerTrainee>(request.TrainerTraineeDto);
                await _uow.TrainerTraineeRepository.Add(trainerTrainee);
                await _uow.Save();

                response.Success = true;
                response.Message = "Creation Successfull";
            }

            return response;
        }
    }
}
