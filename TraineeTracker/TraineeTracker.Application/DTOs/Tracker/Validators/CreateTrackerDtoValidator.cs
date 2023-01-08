using FluentValidation;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Application.DTOs.Tracker.Validators
{
    public class CreateTrackerDtoValidator : AbstractValidator<CreateTrackerDto>
    {
        private readonly ITraineeRepository _traineeRepository;

        public CreateTrackerDtoValidator(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;

            RuleFor(t => t.TraineeId)
                .MustAsync(async (id, token) => await _traineeRepository.Exists(id))
                .WithMessage("{PropertyName} does not exist.");

            Include(new TackerDtoValidator());
        }
    }
}
