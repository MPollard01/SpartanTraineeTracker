using FluentValidation;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Application.DTOs.Trainee.Validators
{
    public class CreateTraineeDtoValidator : AbstractValidator<CreateTraineeDto>
    {
        private readonly ITraineeRepository _traineeRepository;

        public CreateTraineeDtoValidator(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;

            RuleFor(t => t.Id)
                .MustAsync(async (id, token) =>
                {
                    var exists = await _traineeRepository.Exists(id);
                    return !exists;
                })
                .WithMessage("{PropertyName} already exists.");
        }
    }
}
