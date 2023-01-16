using FluentValidation;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Application.DTOs.TrainerTrainee.Validators
{
    public class CreateTrainerTraineeDtoValidator : AbstractValidator<CreateTrainerTraineeDto>
    {
        private IUnitOfWork _unitOfWork;

        public CreateTrainerTraineeDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            //RuleFor(tt => tt.TrainerId)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var exists = await _unitOfWork.TrainerRepository.Exists(id);
            //        return !exists;
            //    })
            //    .WithMessage("{PropertyName} already exists.");

            //RuleFor(tt => tt.TraineeId)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var exists = await _unitOfWork.TraineeRepository.Exists(id);
            //        return exists;
            //    })
            //    .WithMessage("{PropertyName} already exists.");
        }
    }
}
