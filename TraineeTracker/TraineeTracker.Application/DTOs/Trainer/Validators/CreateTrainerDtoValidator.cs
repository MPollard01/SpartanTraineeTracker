﻿using FluentValidation;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Application.DTOs.Trainer.Validators
{
    public class CreateTrainerDtoValidator : AbstractValidator<CreateTrainerDto>
    {
        private readonly ITrainerRepository _trainerRepository;

        public CreateTrainerDtoValidator(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;

            RuleFor(t => t.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} cannot be null or empty.");
            RuleFor(t => t.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} cannot be null or empty.");
            RuleFor(t => t.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} cannot be null or empty.");
            RuleFor(t => t.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} cannot be null or empty.");

            RuleFor(t => t.Id)
                .MustAsync(async (id, token) =>
                {
                    var exists = await _trainerRepository.Exists(id);
                    return !exists;
                })
                .WithMessage("{PropertyName} already exists.");
        }
    }
}
