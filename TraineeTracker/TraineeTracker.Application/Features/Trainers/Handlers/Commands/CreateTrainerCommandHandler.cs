using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainer.Validators;
using TraineeTracker.Application.Features.Trainers.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Features.Trainers.Handlers.Commands
{
    public class CreateTrainerCommandHandler : IRequestHandler<CreateTrainerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateTrainerCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTrainerDtoValidator(_uow.TrainerRepository);

            var validationResult = await validator.ValidateAsync(request.TrainerDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var trainer = _mapper.Map<Trainer>(request.TrainerDto);
                await _uow.TrainerRepository.Add(trainer);
                await _uow.Save();

                response.Success = true;
                response.Message = "Creation Successfull";
            }

            return response;
        }
    }
}
