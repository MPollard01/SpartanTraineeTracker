﻿using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.DTOs.Trainer;

namespace TraineeTracker.Application.DTOs.Trainee
{
    public class TraineeDetailDto : ITraineeDto
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public CourseDto Course { get; set; }
        public List<TrainerForTraineeDetailDto> Trainers { get; set; }
    }
}
