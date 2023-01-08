using TraineeTracker.Application.DTOs.Common;

namespace TraineeTracker.Application.DTOs.Tracker
{
    public class TrackerDto : BaseDto, ITrackerDto
    {
        public string Start { get; set; } = null!;
        public string Stop { get; set; } = null!;
        public string Continue { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public string TechnicalSkill { get; set; } = null!;
        public string ConsultantSkill { get; set; } = null!;
    }
}
