using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee.Validators;
using TraineeTracker.Application.Features.Trainees.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.Trainees.Handlers.Commands
{
    public class CreateTraineeCommandHandler : IRequestHandler<CreateTraineeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateTraineeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeDtoValidator(_uow.TraineeRepository);
            var validationResult = await validator.ValidateAsync(request.TraineeDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var trainee = _mapper.Map<Trainee>(request.TraineeDto);
                await _uow.TraineeRepository.Add(trainee);
                await _uow.Save();

                response.Success = true;
                response.Message = "Creation Successfull";
            }

            return response;
        }
    }
}
