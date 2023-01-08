using FluentValidation;

namespace TraineeTracker.Application.DTOs.Tracker.Validators
{
    public class TackerDtoValidator : AbstractValidator<ITrackerDto>
    {
        public TackerDtoValidator()
        {
            RuleFor(t => t.Start)
                .MinimumLength(3)
                .WithMessage("{PropertyName} must not be less than {ComparisonValue}.");
            RuleFor(t => t.Stop)
                .MinimumLength(3)
                .WithMessage("{PropertyName} must not be less than {ComparisonValue}.");
            RuleFor(t => t.Continue)
                .MinimumLength(3)
                .WithMessage("{PropertyName} must not be less than {ComparisonValue}.");
        }
    }
}
