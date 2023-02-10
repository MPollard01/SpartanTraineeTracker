using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Models
{
    public class AdminHomeVM
    {
        public int UserCount { get; set; }
        public int TrackerCount { get; set; }
        public int TrainerCount { get; set; }
        public int TraineeCount { get; set; }
        public int[] ConsultantSkillCount { get; set; }
        public int[] TechnicalSkillCount { get; set; }
        public int[] TrackersPerMonth { get; set; }
    }

    public class TrainerHomeVM
    {
        public int TrackerCount { get; set; }
        public int TraineeCount { get; set; }
        public int[] ConsultantSkillCount { get; set; }
        public int[] TechnicalSkillCount { get; set; }
        public int[] TrackersPerMonth { get; set; }
    }

    public class TraineeHomeVM
    {
        public bool HasThisWeeksTracker { get; set; }
        public int[] ConsultantSkillCount { get; set; }
        public int[] TechnicalSkillCount { get; set; }
        public string Token { get; set; }
    }
}
