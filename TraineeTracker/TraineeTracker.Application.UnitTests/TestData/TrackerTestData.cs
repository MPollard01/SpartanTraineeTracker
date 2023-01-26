using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.TestData
{
    internal class TrackerTestData
    {
        internal static List<Tracker> trackers = new List<Tracker>
        {
            new Tracker
            {
                Id = 1,
                Start = "Studying every day",
                Stop = "Making silly mistakes",
                Continue = "Learning C#",
                StartDate = new DateTime(2022, 10, 12),
                CreatedDate = new DateTime(2022, 10, 12),
                TechnicalSkill = "Skilled",
                ConsultantSkill = "Partially Skilled",
                TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                CreatedBy = "Carl Angle"
            }
        };
    }
}
