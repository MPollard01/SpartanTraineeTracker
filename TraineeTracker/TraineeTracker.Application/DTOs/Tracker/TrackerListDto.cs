using TraineeTracker.Application.DTOs.Common;
using TraineeTracker.Application.DTOs.Trainee;

namespace TraineeTracker.Application.DTOs.Tracker
{
    public class TrackerListDto : BaseDto, ITrackerDto
    {
        public string Start { get; set; } = null!;
        public string Stop { get; set; } = null!;
        public string Continue { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public string TechnicalSkill { get; set; } = null!;
        public string ConsultantSkill { get; set; } = null!;
        public TraineeDto Trainee { get; set; }
    }
}
