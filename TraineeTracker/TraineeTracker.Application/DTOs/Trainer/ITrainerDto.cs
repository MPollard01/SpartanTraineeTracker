﻿
namespace TraineeTracker.Application.DTOs.Trainer
{
    public interface ITrainerDto
    {
        public string Id { get; set; } 
        public string Email { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
