using FluentValidation;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Application.DTOs.TraineeTest.Validators
{
    public class CreateTraineeTestDtoValidator : AbstractValidator<CreateTraineeTestDto>
    {
        private readonly ISubCategoryRepository _categoryRepository;
        public CreateTraineeTestDtoValidator(ISubCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.SubCategoryId)
                .MustAsync(async (id, token) => await _categoryRepository.Exists(id))
                .WithMessage("{PropertyName} does not exist");
            
        }
    }
}
