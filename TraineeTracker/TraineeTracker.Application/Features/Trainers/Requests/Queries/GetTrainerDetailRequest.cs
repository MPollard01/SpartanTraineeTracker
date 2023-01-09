﻿using MediatR;
using TraineeTracker.Application.DTOs.Trainer;

namespace TraineeTracker.Application.Features.Trainers.Requests.Queries
{
    public class GetTrainerDetailRequest : IRequest<TrainerDto>
    {
        public string Id { get; set; }
    }
}
