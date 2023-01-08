
namespace TraineeTracker.Application.DTOs.Tracker
{
    public interface ITrackerDto
    {
        public string Start { get; set; }
        public string Stop { get; set; }
        public string Continue { get; set; }
        public DateTime StartDate { get; set; }
        public string TechnicalSkill { get; set; } 
        public string ConsultantSkill { get; set; } 
    }
}
