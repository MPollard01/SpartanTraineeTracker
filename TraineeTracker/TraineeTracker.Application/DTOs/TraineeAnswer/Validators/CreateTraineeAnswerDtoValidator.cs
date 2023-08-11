using FluentValidation;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Application.DTOs.TraineeAnswer.Validators
{
    public class CreateTraineeAnswerDtoValidator : AbstractValidator<CreateTraineeAnswerDto>
    {
        private readonly ITraineeTestRepository _traineeTestRepository;
        public CreateTraineeAnswerDtoValidator(ITraineeTestRepository traineeTestRepository)
        {
            _traineeTestRepository = traineeTestRepository;

            RuleFor(x => x.Answer)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null");
            RuleFor(t => t.TraineeTestId)
                .MustAsync(async (id, token) => await _traineeTestRepository.Exists(id))
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
