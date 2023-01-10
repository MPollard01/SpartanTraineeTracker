﻿namespace TraineeTracker.MVC.Models
{
    public class TrainerVM
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<CourseVM> Course { get; set; }
        public List<TraineeVM> Trainers { get; set; }
    }

    public class TrainerListVM
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
