using FluentValidation;

namespace TraineeTracker.Application.DTOs.Trainer.Validators
{
    public class TrainerDtoValidator : AbstractValidator<ITrainerDto>
    {
        public TrainerDtoValidator()
        {
            RuleFor(t => t.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Invalid {PropertyName}.");
            RuleFor(t => t.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(t => t.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty");
        }
    }
}
