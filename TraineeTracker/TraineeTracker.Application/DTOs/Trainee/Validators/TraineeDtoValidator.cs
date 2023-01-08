using FluentValidation;

namespace TraineeTracker.Application.DTOs.Trainee.Validators
{
    public class TraineeDtoValidator : AbstractValidator<ITraineeDto>
    {
        public TraineeDtoValidator()
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
