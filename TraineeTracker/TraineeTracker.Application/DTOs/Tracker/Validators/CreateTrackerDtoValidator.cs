using FluentValidation;

namespace TraineeTracker.Application.DTOs.Tracker.Validators
{
    public class CreateTrackerDtoValidator : AbstractValidator<CreateTrackerDto>
    {
        public CreateTrackerDtoValidator()
        {
            Include(new TackerDtoValidator());
        }
    }
}
