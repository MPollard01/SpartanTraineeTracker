using FluentValidation;

namespace TraineeTracker.Application.DTOs.Course.Validators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseDtoValidator()
        {
            RuleFor(c => c.Title)
                .MinimumLength(3)
                .WithMessage("{PropertyName} must not be less than {ComparisonValue}.");
        }
    }
}
