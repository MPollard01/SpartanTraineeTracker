using TraineeTracker.Domain.Common;

namespace TraineeTracker.Domain
{
    public class Tracker : BaseDomainEntity
    {
        public string Start { get; set; } = null!;
        public string Stop { get; set; } = null!;
        public string Continue { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public string TechnicalSkill { get; set; } = null!;
        public string ConsultantSkill { get; set; } = null!;
        public string TraineeId { get; set; } = null!;
    }
}
